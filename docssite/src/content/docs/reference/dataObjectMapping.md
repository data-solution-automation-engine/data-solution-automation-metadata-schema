---
title: DataObjectMapping
description: 'The mapping between a source and target data set, table, or file. The DataObjectMapping defines an individual source-to-target mapping (an ETL process). It connects one or more `DataObject` sources to a single `DataObjec'
---

The mapping between a source and target data set, table, or file. The DataObjectMapping defines an individual source-to-target mapping (an ETL process). It connects one or more `DataObject` sources to a single `DataObject` target, with `DataItemMapping`s describing the column-to-column transformations. SourceDataObjects, TargetDataObject, and DataItemMappings are the core elements of a DataObjectMapping.

> **Source of truth:** [DataObjectMapping.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/DataObjectMapping.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `id` | `string` | An optional unique identifier for the Data Object Mapping. |
| `name` | `string` | The name of the Data Object Mapping. Ideally a unique name that identifies the individual mapping. |
| `sourceDataObjects` | `array of DataObject` | The source object(s) of the mapping. Potentially multiple source objects can be mapped to a single target object. |
| `targetDataObject` | `DataObject` | The target object of the mapping. |
| `relatedDataObjects` | `array of DataObject` | Data Objects related to this mapping for purposes other than the source/target relationship, for example lookups, merge joins, or lineage. |
| `relationships` | `array of Relationship` | Relationships defined on the mapping (parent/child, foreign keys, lookups, etc.). |
| `dataItems` | `array of DataItem` | The collection of Data Items specifically associated with this Data Object Mapping, used as sources or targets in the mapping or its business key component mappings. |
| `dataItemMappings` | `array of DataItemMapping` | The collection of individual attribute (column or query) mappings. |
| `businessKeyDefinitions` | `array of BusinessKeyDefinition` | The definition of the Business Key(s) for the Data Object Mapping. |
| `filterCriterion` | `string` | Any filtering that needs to be applied to the source-to-target mapping. |
| `enabled` | `bool` | An indicator which can capture enabling / disabling of an individual source-to-target mapping. |
| `classifications` | `array of DataClassification` | Free-form and optional classification for the mapping for use in data logistics generation logic (evaluation). |
| `extensions` | `array of Extension` | The collection of extension Key/Value pairs. |
| `templateMappings` | `array of TemplateMapping` | The collection of template references that apply to this Data Object Mapping. |
| `notes` | `string` | Free-format notes on the Data Object Mapping. |

