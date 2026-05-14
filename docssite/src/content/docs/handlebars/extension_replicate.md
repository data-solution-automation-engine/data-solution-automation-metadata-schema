---
title: '{{#replicate}}'
description: Block helper that repeats the body the specified number of times. Often used for generating test data.
---

Repeats the body block the specified number of times.

Often used to generate test data.

## Usage

```handlebars
{{#replicate 10}}
```

## Example

```handlebars
{{#replicate 3}}
This value is replicated 3 times!
{{/replicate}}
```

This returns:

```text
This value is replicated 3 times!
This value is replicated 3 times!
This value is replicated 3 times!
```
