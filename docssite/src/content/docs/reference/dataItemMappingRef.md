---
title: DataItemMappingRef
description: 'A lightweight, identifier-based variant of `DataItemMapping` for use inside a `Relationship`. Instead of embedding the full source and target Data Items (which already live elsewhere in the mapping), this form references'
---

A lightweight, identifier-based variant of `DataItemMapping` for use inside a `Relationship`. Instead of embedding the full source and target Data Items (which already live elsewhere in the mapping), this form references them by Id only - typical for foreign-key style relationships.

> **Source of truth:** [DataItemMappingRef.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/DataItemMappingRef.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `sourceDataItemIds` | `array of string` | The identifiers of the source Data Items. |
| `targetDataItemId` | `string` | The identifier of the target Data Item. |

