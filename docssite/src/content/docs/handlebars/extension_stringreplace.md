---
title: '{{stringreplace}}'
description: Helper that replaces a specified substring within an input string.
---

Parses an input string and replaces a specified part of the contents with a replacement value.

## Usage

```handlebars
{{stringreplace "<input string value>" "<lookup character>" "<replacement character>"}}
```

## Example

```handlebars
This replaces the o's in Hello World with an !: {{stringreplace "Hello World" "o" "!"}}
```

This results in:

```text
This replaces the o's in Hello World with an !: Hell! W!rld
```
