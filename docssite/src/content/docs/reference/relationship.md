---
title: Relationship
description: 'A relationship from one Data Object to another. This can apply at conceptual, logical, and physical levels. Supports lineage relationships (e.g. parent/child), foreign keys, and sub/supertypes.'
---

A relationship from one Data Object to another. This can apply at conceptual, logical, and physical levels. Supports lineage relationships (e.g. parent/child), foreign keys, and sub/supertypes.

> **Source of truth:** [Relationship.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/Relationship.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `id` | `string` | An optional identifier for the relationship. |
| `name` | `string` | The mandatory name of the relationship. |
| `type` | `string` | The type of relationship. Free-format label, for example "parent", "child", or "lookup". |
| `cardinality` | `Cardinality` | Cardinality of the relationship, expressed as min/max ranges on each end. Supports forms like "0 or 1 to many", "1 (and only one) to 1", "zero or many to one", etc. |
| `relatedDataObjectId` | `string` | Identifier-only reference to the related Data Object. Use this when the related object lives elsewhere in the file and should not be embedded. |
| `relatedDataObject` | `DataObject` | The related Data Object, embedded. Used when the JSON contains the full object rather than just an ID reference. |
| `dataItemMappings` | `array of DataItemMappingRef` | The Data Item mappings for foreign-key style relationships, expressed as lightweight identifier references. |
| `classifications` | `array of DataClassification` | Free-form and optional classification for the relationship. |
| `extensions` | `array of Extension` | The collection of extension Key/Value pairs. |
| `notes` | `string` | Free-format notes. |

