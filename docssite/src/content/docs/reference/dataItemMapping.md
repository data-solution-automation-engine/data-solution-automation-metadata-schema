---
title: DataItemMapping
description: 'The individual column-to-column mapping between source and target Data Items.'
---

The individual column-to-column mapping between source and target Data Items.

> **Source of truth:** [DataItemMapping.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/DataItemMapping.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `id` | `string` | Optional identifier as a string value to allow various identifier approaches. |
| `name` | `string` | Optional name for the Data Item Mapping. |
| `sourceDataItems` | `array of DataItem` | The source Data Items of the mapping. |
| `targetDataItem` | `DataItem` | The target Data Item of the mapping. |
| `extensions` | `array of Extension` | The collection of extension Key/Value pairs. |
| `notes` | `string` | Free-format notes. |

