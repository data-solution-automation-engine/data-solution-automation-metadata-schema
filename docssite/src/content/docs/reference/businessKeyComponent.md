---
title: BusinessKeyComponent
description: 'An individual component of a `BusinessKeyDefinition`. A business key is composed of one or more components, each referencing a Data Item. The ordinal position records the order of the components within the business key, '
---

An individual component of a `BusinessKeyDefinition`. A business key is composed of one or more components, each referencing a Data Item. The ordinal position records the order of the components within the business key, which can be meaningful.

> **Source of truth:** [BusinessKeyComponent.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/BusinessKeyComponent.cs)

## Required properties

| JSON name | Type | Description |
|---|---|---|
| `ordinalPosition` | `int` | The position of this component within the parent business key definition. |

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `dataItem` | `DataItem` | The Data Item that forms this component of the business key. |

