---
title: DataObjectMappingList
description: 'The schema''s top-level object is a ''DataObjectMappingList''. It is an array of individual source-to-target mappings called ''DataObjectMappings'', commonly referred to as ''mappings''. In code, this means a DataObjectMappingL'
---

The schema's top-level object is a 'DataObjectMappingList'. It is an array of individual source-to-target mappings called 'DataObjectMappings', commonly referred to as 'mappings'. In code, this means a DataObjectMappingList is defined as a List of `DataObjectMapping`. A DataObjectMapping is a unique ETL mapping / transformation that moves, or interprets, data from a given source to a given destination. The decision to start the format with an array / list that contains potentially multiple DataObjectMappings relates to the Data Warehouse virtualization use-case. In these implementations, multiple individual mappings together create a single view object. As an example, consider the loading of a Core Business Concept / Hub type entity from various different sources. If you would use these different mappings to generate ETL processes you would create one physical ETL object for each mapping. However, if you are seeking to generate a view that represents the target table the result you would use the collection (list) of mappings to generate separate statements that are unioned in the single view object.

> **Source of truth:** [DataObjectMappingList.cs](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel/DataObjectMappingList.cs)

## Optional properties

| JSON name | Type | Description |
|---|---|---|
| `id` | `string` | An optional identifier for the Data Object Mapping List. |
| `name` | `string` | The name of the Data Object Mapping List. This is typically provided by one of the data object mappings in the list. It has been added to allow easy identification of the objects in case a list contains many mappings. |
| `notes` | `string` | Free-format notes on the Data Object Mapping List. |
| `dataObjectMappings` | `array of DataObjectMapping` | The top-level object that contains a list of one or more source-to-target mappings. |
| `classifications` | `array of DataClassification` | Free-form and optional classification for the mapping for use in data logistics generation logic. |
| `extensions` | `array of Extension` | The collection of extension Key/Value pairs. |
| `templateMappings` | `array of TemplateMapping` | The collection of template references that apply to this Data Object Mapping List. |

