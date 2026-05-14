---
title: DataClassification
description: 'Used to define a list of classifications (labels) and notes to add to various components of the schema definition.'
---

Used to define a list of classifications (labels) and notes to add to various components of the schema definition.

> **Source of truth:** [DataClassification.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/DataClassification.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `id` | `string` | Optional identifier as a string value to allow various identifier approaches. |
| `classification` | `string` | The mandatory classification description, usually a keyword used for automation purposes. |
| `group` | `string` | The grouping or category for this classification (e.g. "Solution Layer", "Logical", "Physical"). Used to organise classifications into related sets. |
| `scope` | `array of string` | The scope areas in which this classification is applicable. When null or empty, the classification applies everywhere. Values are camelCase tokens such as "dataObjects", "connections", "mappings", "templates", "graph". |
| `notes` | `string` | Free-format notes on the Data Classification. |

