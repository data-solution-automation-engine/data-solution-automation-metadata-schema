---
title: Cardinality
description: 'Captures the cardinality and ordinality of a relationship. Cardinality defines the number of occurrences of one entity that are associated with the number of occurrences of another entity through a relationship.'
---

Captures the cardinality and ordinality of a relationship. Cardinality defines the number of occurrences of one entity that are associated with the number of occurrences of another entity through a relationship.

> **Source of truth:** [Cardinality.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/Cardinality.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `id` | `string` | Optional identifier as a string value to allow various identifier approaches. |
| `name` | `string` | Optional name for a recognised cardinality construct, for example "one-to-one", "one-to-many", or "many-to-many". E.g. one-to-one corresponds to \{"fromRange": \{"min": "1", "max": "1"\}, "toRange": \{"min": "1", "max": "1"\}\}. |
| `fromRange` | `CardinalityRange` | The 'from' component of the cardinality (e.g. the '1' in 1-to-many). |
| `toRange` | `CardinalityRange` | The 'to' component of the cardinality (e.g. the 'many' in 1-to-many). |
| `classifications` | `array of DataClassification` | Free-form and optional classification for the Cardinality for use in generation logic (evaluation). |
| `extensions` | `array of Extension` | The collection of extension Key/Value pairs. |
| `notes` | `string` | Free-format notes. |

