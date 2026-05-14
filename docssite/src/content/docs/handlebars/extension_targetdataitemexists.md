---
title: '{{#targetDataItemExists}}'
description: Block helper that checks whether a given data item name exists among the target data items of a mapping.
---

This block helper extension specifically applies to the schema for data solution automation.

The helper searches the target data items within a data item mapping and evaluates whether the input value exists there as a data item name. This is used in some cases to handle special column names.

## Usage

```handlebars
{{#targetDataItemExists "<value>"}} do something {{else}} do something else {{/targetDataItemExists}}
```

## Example

```handlebars
{{#targetDataItemExists "FIRST_NAME"}}FIRST_NAME exists{{else}}FIRST_NAME does not exist{{/targetDataItemExists}}
```

This results in:

```text
FIRST_NAME exists
```
