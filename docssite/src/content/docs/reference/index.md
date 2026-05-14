---
title: Schema reference
description: Generated reference for every type in the Data Solution Automation schema.
sidebar:
  order: 0
---

The schema is defined in C# at [`DataSolutionAutomation/DsaModel`](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/tree/main/DataSolutionAutomation/DataSolutionAutomation/DsaModel) and shipped as [`DataSolutionAutomation`](https://www.nuget.org/packages/DataSolutionAutomation) on NuGet. The pages here are generated directly from those C# files - the C# library is the canonical description, and the JSON Schema file at [`GenericInterface/interfaceDataSolutionAutomationMetadataV2_1.json`](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/GenericInterface/interfaceDataSolutionAutomationMetadataV2_1.json) mirrors the same shape for validation.

## Types

- [`BusinessKeyComponent`](./businessKeyComponent/) - An individual component of a `BusinessKeyDefinition`. A business key is composed of one or more components, each referencing a Data Item. The ordinal position records the order of 
- [`BusinessKeyDefinition`](./businessKeyDefinition/) - A business key definition is a special object that is defined as an optional property of a data object mapping. It captures how a business key is composed from one or more `Busines
- [`Cardinality`](./cardinality/) - Captures the cardinality and ordinality of a relationship. Cardinality defines the number of occurrences of one entity that are associated with the number of occurrences of another
- [`CardinalityRange`](./cardinalityRange/) - A min/max range used for one end (from or to) of a `Cardinality`. For example "min": "1", "max": "N" expresses "at least one, possibly many".
- [`DataClassification`](./dataClassification/) - Used to define a list of classifications (labels) and notes to add to various components of the schema definition.
- [`DataConnection`](./dataConnection/) - Connectivity information, that can be used for either a DataObject or DataObjectQuery. This is be a key, token, reference, connection string and similar.
- [`DataItem`](./dataItem/) - Data items belong to data objects. They describe the individual elements, such as the columns in a table or headers in a file. A Data Item can also represent a query expression (a 
- [`DataItemMapping`](./dataItemMapping/) - The individual column-to-column mapping between source and target Data Items.
- [`DataItemMappingRef`](./dataItemMappingRef/) - A lightweight, identifier-based variant of `DataItemMapping` for use inside a `Relationship`. Instead of embedding the full source and target Data Items (which already live elsewhe
- [`DataObject`](./dataObject/) - The definition of a data set, file, or table. A Data Object can be the source or target in a `DataObjectMapping`. A Data Object can also represent a query (a view, script, or proce
- [`DataObjectMapping`](./dataObjectMapping/) - The mapping between a source and target data set, table, or file. The DataObjectMapping defines an individual source-to-target mapping (an ETL process). It connects one or more `Da
- [`DataObjectMappingList`](./dataObjectMappingList/) - The schema's top-level object is a 'DataObjectMappingList'. It is an array of individual source-to-target mappings called 'DataObjectMappings', commonly referred to as 'mappings'. 
- [`Extension`](./extension/) - A free form key/value pair addition that can contain additional context.
- [`Relationship`](./relationship/) - A relationship from one Data Object to another. This can apply at conceptual, logical, and physical levels. Supports lineage relationships (e.g. parent/child), foreign keys, and su
- [`TemplateMapping`](./templateMapping/) - A reference to a template file that should be applied to the parent object. Template mappings let metadata travel together with the templates used to generate code from it.

