---
title: DataItem
description: 'Data items belong to data objects. They describe the individual elements, such as the columns in a table or headers in a file. A Data Item can also represent a query expression (a calculated column) by setting `QueryCode'
---

Data items belong to data objects. They describe the individual elements, such as the columns in a table or headers in a file. A Data Item can also represent a query expression (a calculated column) by setting `QueryCode` and optionally `QueryLanguage`.

> **Source of truth:** [DataItem.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/DataItem.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `id` | `string` | Identifier as a string value to allow various identifier approaches. |
| `name` | `string` | The mandatory name of the Data Item. |
| `dataType` | `string` | The data type of the Data Item (e.g. VARCHAR, int, text). |
| `characterLength` | `int` | The character length for text-typed Data Items. |
| `numericPrecision` | `int` | The numeric precision (total digits). |
| `numericScale` | `int` | The numeric scale (digits to the right of the decimal point). |
| `ordinalPosition` | `int` | The ordinal position of this item within its parent Data Object. |
| `isPrimaryKey` | `bool` | Indicates whether this item is part of a Primary Key. |
| `isNullable` | `bool` | Indicates whether this item accepts null values. |
| `queryCode` | `string` | When set, the Data Item represents a query expression (a calculated column) rather than a stored column. |
| `queryLanguage` | `string` | The language that `QueryCode` is written in (e.g. SQL). |
| `classifications` | `array of DataClassification` | Free-form and optional classification for the Data Item for use in generation logic (evaluation). |
| `extensions` | `array of Extension` | The collection of extension Key/Value pairs. |
| `notes` | `string` | Free-format notes. |

