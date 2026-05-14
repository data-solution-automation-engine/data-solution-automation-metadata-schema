---
title: DataObject
description: 'The definition of a data set, file, or table. A Data Object can be the source or target in a `DataObjectMapping`. A Data Object can also represent a query (a view, script, or procedure) by setting `QueryCode` and optiona'
---

The definition of a data set, file, or table. A Data Object can be the source or target in a `DataObjectMapping`. A Data Object can also represent a query (a view, script, or procedure) by setting `QueryCode` and optionally `QueryLanguage`.

> **Source of truth:** [DataObject.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/DataObject.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `id` | `string` | An optional identifier for the Data Object. |
| `name` | `string` | The mandatory name of the Data Object. |
| `dataConnection` | `DataConnection` | The connection information associated with the Data Object. |
| `dataItems` | `array of DataItem` | The collection of Data Items associated with this Data Object. |
| `queryCode` | `string` | When set, the Data Object represents a query (view, script, or procedure) rather than a stored table. |
| `queryLanguage` | `string` | The language that `QueryCode` is written in (e.g. SQL). |
| `businessKeyDefinitions` | `array of BusinessKeyDefinition` | The definition of the Business Key(s) for the Data Object. Capturing the business key definition here supports defining a series of business keys against the source Data Object and reusing these across different Data Object Mappings. |
| `relationships` | `array of Relationship` | Relationships to other Data Objects (parent/child, foreign keys, lookups, etc.). |
| `classifications` | `array of DataClassification` | Free-form and optional classification for the Data Object. |
| `extensions` | `array of Extension` | The collection of extension Key/Value pairs. |
| `templateMappings` | `array of TemplateMapping` | The collection of template references that apply to this Data Object. |
| `notes` | `string` | Free-format notes. |

