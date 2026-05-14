---
title: How the schema works
description: A walk-through of the JSON schema, its key objects, and the way mappings are composed.
sidebar:
  order: 2
---

The **interface for data solution automation metadata** provides an agreed (canonical) format for the exchange of relevant metadata for data solution / warehouse automation. The intent is to define a *sufficiently generic* format that can record and share data solution automation metadata, so that more time can be spent on concepts, patterns, and solution ideas - instead of reinventing what exactly is required to automate a data solution.

This aims to facilitate greater interoperability between various data solution / data solution automation and data logistics generation approaches and ecosystems.

The schema definition can be viewed [here](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/GenericInterface/interfaceDataSolutionAutomationMetadataV2_1.json), and is part of [this GitHub repository](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema). The repository contains supporting components such as:

- A class library (`DataSolutionAutomation.dll`) that implements the schema structure and includes a validation function to test JSON files / messages against the schema.
- Starter documentation.
- A sample implementation that generates code using [Handlebars.Net](https://roelantvos.com/blog/using-handlebars-to-generate-data-vault-hub-load-processes/), which produces code from a sample JSON file conforming to the interface schema.
- A regression test application demonstrating different usages of the schema.

The schema is validated using standards from [json-schema.org](https://json-schema.org/) (see [miscellaneous examples](https://json-schema.org/learn/miscellaneous-examples.html)). In principle the schema can describe an entire Data Warehouse, Data Lake, or equivalent.

## How does the interface schema work?

The interface is a JSON Schema Definition following draft 7 of the JSON schema. It contains reusable definitions ('definitions') that are implemented as a source-to-target mapping object called a 'Data Object Mapping'.

The Data Object Mapping is literally a mapping between Data Objects. It is a unique ETL mapping or transformation that moves or interprets data from a given source to a given destination.

At a high level there are two elements that form the core of a Data Object Mapping:

- The **Data Object** defines the source and target of the Data Object Mapping. A Data Object can optionally have a connection defined as a string or token, and can represent a table, file, or query (by setting `queryCode`).
- The **Data Item** belongs to a Data Object and represents an individual column or calculated expression in a Data Object Mapping.

## Mapping metadata

A Data Object Mapping reuses the definitions of the Data Object and Data Item. The Data Object is used twice: as the `sourceDataObjects` and as the `targetDataObject`.

The other key component of a Data Object Mapping is the **Data Item Mapping**, which describes the column-to-column (or transformation-to-column) and reuses the Data Item class.

Source Data Objects, Target Data Object, and Data Item Mappings are the mandatory components of a Data Object Mapping.

There are many other attributes that can be set, and there are mandatory items within Data Objects and Data Items. These are described in the schema, and the validation functions make it easy to try out different uses of the schema.

One of the goals in defining this schema has been to find a balance between being too generic and too specific (restrictive). For this reason there are only a few mandatory elements.

It is also possible to add a **Business Key Definition** to a Data Object Mapping. This construct reuses the earlier definitions but can optionally be added as a specially-classified set of transformations.

## Mapping collections

At the top level, one or more Data Object Mappings are grouped into a single **Data Object Mapping List**. The convention is that, even if only a single Data Object Mapping is needed in a message or file, it is *always* part of a Data Object Mapping List.

In code, this means a Data Object Mapping List is defined as a `List<DataObjectMapping>`.

The decision to start the format with an array of Data Object Mappings relates to the Data Warehouse virtualisation use-case. In this style of implementation, multiple individual mappings together create a single view object. Testing revealed it is much harder to piece relationships between mappings together at a later stage to create a single (view) object - having the option to define a collection makes this easy.

For example, consider loading a Core Business Concept ('Hub') type entity from various data sources. If you use these mappings to generate ETL processes you'd create one physical ETL object per mapping. But if you're generating a view that represents the target table, you'd use the collection of mappings to generate separate statements unioned in a single view.

## Example

A minimal example, with a single Data Object Mapping in a Data Object Mapping List:

```json
{
  "dataObjectMappings": [
    {
      "name": "Mapping1",
      "sourceDataObjects": [
        { "name": "SourceTable" }
      ],
      "targetDataObject": { "name": "TargetTable" },
      "dataItemMappings": [
        {
          "sourceDataItems": [ { "name": "SourceColumn1" } ],
          "targetDataItem":   { "name": "TargetColumn1" }
        },
        {
          "sourceDataItems": [ { "name": "SourceColumn2" } ],
          "targetDataItem":   { "name": "TargetColumn2" }
        }
      ]
    }
  ]
}
```
