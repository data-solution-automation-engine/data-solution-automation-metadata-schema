#!/usr/bin/env node
/**
 * Generates Starlight MDX reference pages from the DataSolutionAutomation C# class library.
 *
 * The C# files at ../DataSolutionAutomation/DataSolutionAutomation/DsaModel/*.cs are the
 * canonical schema definition (they ship as DataSolutionAutomation.dll, are consumed by ADL,
 * TEAM, VDW, etc.). This script extracts the XML doc comments and property metadata and emits
 * one MDX file per type under src/content/docs/reference/.
 *
 * Run: `node scripts/generate-schema-reference.mjs`
 */

import { readFileSync, readdirSync, writeFileSync, mkdirSync, rmSync, existsSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, join, resolve } from 'node:path';

const here = dirname(fileURLToPath(import.meta.url));
const repoRoot = resolve(here, '..', '..');
const dsaModelDir = resolve(repoRoot, 'DataSolutionAutomation', 'DataSolutionAutomation', 'DsaModel');
const outputDir = resolve(here, '..', 'src', 'content', 'docs', 'reference');

const SKIP_FILES = new Set([
  // Interfaces are gone in v2.1, but skip any leftovers defensively.
  'IDataItem.cs',
  'IDataObject.cs',
  'IMetadata.cs',
]);

/** Strip /// from a doc-comment line and trim. */
function cleanDocLine(line) {
  return line.replace(/^\s*\/\/\/\s?/, '').trimEnd();
}

/** Join lines of a doc comment, preserving paragraphs. */
function joinDoc(lines) {
  return lines
    .map(cleanDocLine)
    .join(' ')
    .replace(/<\/summary>.*$/s, '')
    .replace(/<summary>\s*/, '')
    .replace(/<para>/g, '\n\n')
    .replace(/<\/para>/g, '')
    .replace(/<see cref="([^"]+)" ?\/>/g, '`$1`')
    .replace(/<see cref="([^"]+)">[^<]*<\/see>/g, '`$1`')
    .replace(/\s+/g, ' ')
    .trim();
}

/**
 * Parse a C# class file. Returns { className, summary, properties: [...] } or null
 * if no public class was found.
 */
function parseCsFile(text, fileName) {
  const lines = text.split(/\r?\n/);

  let className = null;
  let classSummary = '';
  const properties = [];

  // Doc comment buffer
  let docBuf = [];

  // Property attribute buffer
  let attrBuf = [];

  for (let i = 0; i < lines.length; i++) {
    const line = lines[i];
    const trimmed = line.trim();

    // Skip empty lines and region markers, but flush doc buffer if needed.
    if (trimmed === '' || trimmed.startsWith('#region') || trimmed.startsWith('#endregion')) {
      continue;
    }

    // Doc comment lines
    if (trimmed.startsWith('///')) {
      docBuf.push(trimmed);
      continue;
    }

    // Attribute lines (e.g. [JsonPropertyName("foo")])
    if (trimmed.startsWith('[')) {
      attrBuf.push(trimmed);
      continue;
    }

    // Class declaration
    const classMatch = trimmed.match(/^public\s+(?:sealed\s+|abstract\s+)?class\s+(\w+)/);
    if (classMatch) {
      className = classMatch[1];
      classSummary = joinDoc(docBuf);
      docBuf = [];
      attrBuf = [];
      continue;
    }

    // Property declaration (auto-property)
    const propMatch = trimmed.match(/^public\s+([\w<>\?\[\]\s,]+?)\s+(\w+)\s*\{\s*get;\s*set;\s*\}(.*)$/);
    if (propMatch) {
      const csType = propMatch[1].trim();
      const csName = propMatch[2];
      const tail = propMatch[3] || '';

      // Default-value detection (e.g. `= "NewDataObject";`, `= new();`, `= [];`)
      let defaultValue = null;
      const defaultMatch = tail.match(/=\s*(.+);\s*$/);
      if (defaultMatch) {
        defaultValue = defaultMatch[1].trim();
      } else {
        // Could also be on the next line(s)
        let look = i + 1;
        while (look < lines.length) {
          const next = lines[look].trim();
          if (next === '') {
            look++;
            continue;
          }
          const dm = next.match(/^=\s*(.+);\s*$/);
          if (dm) {
            defaultValue = dm[1].trim();
          }
          break;
        }
      }

      // JsonPropertyName from attribute buffer
      let jsonName = csName.charAt(0).toLowerCase() + csName.slice(1);
      let isIgnored = false;
      for (const attr of attrBuf) {
        const nameMatch = attr.match(/JsonPropertyName\("([^"]+)"\)/);
        if (nameMatch) jsonName = nameMatch[1];
        if (attr.includes('JsonIgnore') && attr.includes('JsonIgnoreCondition.Always')) {
          isIgnored = true;
        }
      }

      if (!isIgnored) {
        const nullable = csType.endsWith('?') || /\bnull\b/.test(csType);
        properties.push({
          csName,
          csType,
          jsonName,
          summary: joinDoc(docBuf),
          nullable,
          defaultValue,
        });
      }

      docBuf = [];
      attrBuf = [];
      continue;
    }

    // Method, constructor, or block opener / closer - reset attribute buffer but keep doc for class.
    if (
      trimmed.startsWith('public ') ||
      trimmed.startsWith('private ') ||
      trimmed.startsWith('internal ') ||
      trimmed === '{' ||
      trimmed === '}'
    ) {
      // If we have a doc buf and haven't found a class yet, keep buffering until class.
      if (className !== null) {
        docBuf = [];
        attrBuf = [];
      }
    }
  }

  if (!className) return null;
  return { className, classSummary, properties, fileName };
}

/** Format a C# type for the reference table. */
function formatType(csType) {
  // Strip nullable marker; the "Required" column carries that info.
  let t = csType.replace(/\?$/, '');
  // Convert C# generics to a readable form: List<DataItem> -> array of DataItem
  const list = t.match(/^List<(.+)>$/);
  if (list) return `array of ${list[1]}`;
  return t;
}

function isRequired(prop, className) {
  // Heuristic: a property is "required" if it's non-nullable AND not initialised with a default
  // that makes it optional in practice.
  if (prop.nullable) return false;
  // Exclude bool/int defaults
  if (prop.defaultValue && prop.defaultValue !== 'null') return false;
  return true;
}

function escapeFrontmatter(s) {
  return s.replace(/'/g, "''");
}

/** Escape characters that MDX/JSX would otherwise interpret. */
function escapeMdx(s) {
  if (!s) return s;
  return s.replace(/\{/g, '\\{').replace(/\}/g, '\\}').replace(/</g, '&lt;').replace(/>/g, '&gt;');
}

/** Render an MDX page for one class. */
function renderMdx(parsed) {
  const { className, classSummary, properties } = parsed;

  const required = properties.filter((p) => isRequired(p, className));
  const optional = properties.filter((p) => !isRequired(p, className));

  const titleLower = className.charAt(0).toLowerCase() + className.slice(1);
  const description = (classSummary || `Reference for ${className}.`).slice(0, 220);

  let body = '';
  body += `---\n`;
  body += `title: ${className}\n`;
  body += `description: '${escapeFrontmatter(description)}'\n`;
  body += `---\n\n`;
  body += `${escapeMdx(classSummary)}\n\n`;
  body += `> **Source of truth:** [${parsed.fileName}](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/${parsed.fileName})\n\n`;

  if (required.length > 0) {
    body += `## Required properties\n\n`;
    body += renderPropertyTable(required);
  }

  if (optional.length > 0) {
    body += `## Optional properties\n\n`;
    body += renderPropertyTable(optional);
  }

  if (properties.length === 0) {
    body += `_No serialisable properties._\n`;
  }

  return body;
}

function renderPropertyTable(props) {
  let out = '';
  out += `| JSON name | Type | Description |\n`;
  out += `|---|---|---|\n`;
  for (const p of props) {
    const desc = escapeMdx((p.summary || '').replace(/\|/g, '\\|'));
    out += `| \`${p.jsonName}\` | \`${formatType(p.csType)}\` | ${desc} |\n`;
  }
  return out + '\n';
}

function renderIndex(parsedClasses) {
  let body = '';
  body += `---\n`;
  body += `title: Schema reference\n`;
  body += `description: Generated reference for every type in the Data Solution Automation schema.\n`;
  body += `sidebar:\n  order: 0\n`;
  body += `---\n\n`;
  body += `The schema is defined in C# at [\`DataSolutionAutomation/DsaModel\`](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/tree/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel) and shipped as [\`DataSolutionAutomation\`](https://www.nuget.org/packages/DataSolutionAutomation) on NuGet. The pages here are generated directly from those C# files - the C# library is the canonical description, and the JSON Schema file at [\`GenericInterface/interfaceDataSolutionAutomationMetadataV2_1.json\`](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/GenericInterface/interfaceDataSolutionAutomationMetadataV2_1.json) mirrors the same shape for validation.\n\n`;
  body += `## Types\n\n`;
  const sorted = [...parsedClasses].sort((a, b) => a.className.localeCompare(b.className));
  for (const p of sorted) {
    const slug = p.className.charAt(0).toLowerCase() + p.className.slice(1);
    const desc = (p.classSummary || '').replace(/\|/g, '\\|').slice(0, 180);
    body += `- [\`${p.className}\`](./${slug}/) - ${desc}\n`;
  }
  return body + '\n';
}

// ---- main ----

if (!existsSync(dsaModelDir)) {
  console.error(`DsaModel directory not found: ${dsaModelDir}`);
  process.exit(1);
}

// Clean the output directory so deleted types don't linger
if (existsSync(outputDir)) {
  rmSync(outputDir, { recursive: true, force: true });
}
mkdirSync(outputDir, { recursive: true });

const csFiles = readdirSync(dsaModelDir).filter(
  (f) => f.endsWith('.cs') && !SKIP_FILES.has(f),
);

const parsedClasses = [];
for (const fileName of csFiles) {
  const filePath = join(dsaModelDir, fileName);
  const text = readFileSync(filePath, 'utf8');
  const parsed = parseCsFile(text, fileName);
  if (!parsed) {
    console.warn(`  skipped (no public class found): ${fileName}`);
    continue;
  }
  parsedClasses.push(parsed);

  const slug = parsed.className.charAt(0).toLowerCase() + parsed.className.slice(1);
  const outPath = join(outputDir, `${slug}.md`);
  writeFileSync(outPath, renderMdx(parsed), 'utf8');
  console.log(`  wrote ${slug}.md (${parsed.properties.length} properties)`);
}

// Write the reference index page
writeFileSync(join(outputDir, 'index.md'), renderIndex(parsedClasses), 'utf8');
console.log(`  wrote index.md (${parsedClasses.length} types)`);

console.log(`\nDone. Reference pages written to ${outputDir}`);
