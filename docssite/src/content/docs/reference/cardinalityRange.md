---
title: CardinalityRange
description: 'A min/max range used for one end (from or to) of a `Cardinality`. For example "min": "1", "max": "N" expresses "at least one, possibly many".'
---

A min/max range used for one end (from or to) of a `Cardinality`. For example "min": "1", "max": "N" expresses "at least one, possibly many".

> **Source of truth:** [CardinalityRange.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/CardinalityRange.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `min` | `string` | The lower bound of the range. Typically "0" or "1". |
| `max` | `string` | The upper bound of the range. Typically "1" or "N". |

