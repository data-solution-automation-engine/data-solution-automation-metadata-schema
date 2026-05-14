# Data Solution Automation Schema - Docs Site

Astro + Starlight documentation site for the Data Solution Automation metadata schema.

## Local development

```bash
pnpm install
pnpm dev          # http://localhost:4321/data-solution-automation-metadata-schema
pnpm build        # build to ./dist
pnpm preview      # preview the built site
```

## Content layout

- `src/content/docs/index.mdx` - home page
- `src/content/docs/overview/` - conceptual overview pages
- `src/content/docs/reference/` - schema type reference (one MDX file per type)
- `src/content/docs/handlebars/` - Handlebars helper reference
- `src/content/docs/faq/` - frequently asked questions

Sidebar order is controlled in `astro.config.ts`.

## Schema reference pages

The pages under `src/content/docs/reference/` are generated from the C# class library at
`../DataSolutionAutomation/DataSolutionAutomation/DsaModel/` using
`scripts/generate-schema-reference.mjs`. The C# library (with its XML doc comments) is the
canonical source - regenerate after model changes:

```bash
node scripts/generate-schema-reference.mjs
```

## Deployment

Built and deployed to GitHub Pages by `.github/workflows/docs.yml` on every push to `main`.
Site URL: https://data-solution-automation-engine.github.io/data-solution-automation-metadata-schema/
