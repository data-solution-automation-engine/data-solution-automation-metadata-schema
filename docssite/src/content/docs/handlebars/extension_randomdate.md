---
title: '{{randomdate}}'
description: Generates a random date later than the supplied four-digit year. Useful for test data and referential-integrity testing.
---

Generates a random date later than the supplied four-digit year (integer).

Originally added to generate test data, and used for referential-integrity testing purposes.

## Usage

```handlebars
{{randomdate 2020}}
```

## Example

```handlebars
Here is a random date: {{randomdate 2020}}.
```

This may return:

```text
2022-08-03T00:00:00.000000
```
