---
title: Handlebars helpers
description: Overview of the Handlebars custom extensions available when generating code with the Data Solution Automation schema.
sidebar:
  order: 0
---

As part of the schema, a number of extensions to the Handlebars templating language are bundled with the `DataSolutionAutomation` library.

## Block helpers

Block helpers have a starting and closing tag, and often support `{{else}}` constructs.

- [`{{#stringcompare}}`](./extension_stringcompare/)
- [`{{#stringdiff}}`](./extension_stringdiff/)
- [`{{#replicate}}`](./extension_replicate/)
- [`{{#exists}}`](./extension_exists/)
- [`{{#targetDataItemExists}}`](./extension_targetdataitemexists/)

## String helpers

String helpers do not use the `#` prefix and have no closing tag. They accept one or more parameter values and return a string to use in the template.

- [`{{now}}`](./extension_now/)
- [`{{randomdate}}`](./extension_randomdate/)
- [`{{randomnumber}}`](./extension_randomnumber/)
- [`{{randomstring}}`](./extension_randomstring/)
- [`{{space}}`](./extension_space/)
- [`{{stringwrap}}`](./extension_stringwrap/)
- [`{{stringreplace}}`](./extension_stringreplace/)
- [`{{lookupExtension}}`](./extension_lookupextension/)
