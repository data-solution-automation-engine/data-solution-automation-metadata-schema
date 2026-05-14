---
title: '{{stringwrap}}'
description: Helper that wraps an input string with two specified characters.
---

Wraps an input character string with two specified characters.

## Usage

```handlebars
{{stringwrap "<value>" "<start character>" "<end character>"}}
```

## Example

```handlebars
This adds brackets around the string value: {{stringwrap "Example" "[" "]"}}
```

This results in:

```text
[Example]
```
