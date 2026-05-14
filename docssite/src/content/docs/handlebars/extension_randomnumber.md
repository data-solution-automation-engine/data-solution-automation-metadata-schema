---
title: '{{randomnumber}}'
description: Generates a random number with the numeric positions provided as input integer.
---

Generates a random number with the specified number of digits as input integer.

Originally added to generate test data, and used for referential-integrity testing purposes.

## Usage

```handlebars
{{randomnumber 5}}
```

## Example

```handlebars
And here is a random string: {{randomnumber 5}}.
```

This may return:

```text
1346
```
