---
title: BusinessKeyDefinition
description: 'A business key definition is a special object that is defined as an optional property of a data object mapping. It captures how a business key is composed from one or more `BusinessKeyComponent`s, each referencing a Data'
---

A business key definition is a special object that is defined as an optional property of a data object mapping. It captures how a business key is composed from one or more `BusinessKeyComponent`s, each referencing a Data Item.

> **Source of truth:** [BusinessKeyDefinition.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/BusinessKeyDefinition.cs)

## Required properties

| JSON name | Type | Description |
|---|---|---|
| `ordinalPosition` | `int` | The ordinal position of this business key definition within its parent mapping. Relevant for Link objects that have multiple business keys (one per Hub). |

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `id` | `string` | Optional identifier as a string value to allow various identifier approaches. |
| `name` | `string` | The optional name of the business key definition. |
| `businessKeyComponents` | `array of BusinessKeyComponent` | The components of the business key. The order of components is meaningful and is recorded on each component. |
| `businessKeyComponentMappings` | `array of DataItemMapping` | Legacy pre-v2.1 representation of business key components as Data Item Mappings. Retained for backward-compatible reading of older metadata files; new files should use `BusinessKeyComponents`. |
| `surrogateKey` | `string` | An optional label for the end result e.g. the target business key attribute. |
| `classifications` | `array of DataClassification` | Free-form and optional classification for the business key for use in generation logic (evaluation). |
| `extensions` | `array of Extension` | The collection of extension key/value pairs. |
| `notes` | `string` | Free-format notes. |

