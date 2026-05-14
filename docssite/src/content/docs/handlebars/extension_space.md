---
title: '{{space}}'
description: Pads the input value out to 30 characters for column alignment in generated output.
---

Pads the input value out to 30 characters using whitespace, for column alignment in generated output.

## Usage

```handlebars
{{space "<value>"}}
```

## Example

```handlebars
This is {{space "Hello World"}} ...spaced out.
```

This results in:

```text
This is Hello World                                              ...spaced out.
```
