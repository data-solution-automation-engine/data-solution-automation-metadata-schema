---
title: '{{#stringdiff}}'
description: Block helper that evaluates whether two strings differ, with optional else branch.
---

Block helper that evaluates whether the input does *not* match a specified string. Optionally supports an `{{else}}` block.

## Usage

```handlebars
{{#stringdiff string1 string2}} do something {{else}} do something else {{/stringdiff}}
```

## Example

```handlebars
A and B {{#stringdiff "A" "B"}}are not the same. {{else}}are the same. {{/stringdiff}}
```

This results in:

```text
A and B are not the same.
```
