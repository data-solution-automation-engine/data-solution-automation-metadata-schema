---
title: Frequently Asked Questions
description: Common questions about the Data Solution Automation metadata schema.
---

## Why have a schema definition for Data Solution Automation?

The reason work on the schema definition started is based on a desire to collaborate with various like-minded professionals in the industry, who all had different (proprietary) ways to record metadata. The challenge was how to collaborate on at least the patterns, without necessarily agreeing on 'the best' back-end solution to store metadata.

The interface for Data Solution Automation was started as an initiative that would let everyone use the back-end of their choosing, while still being able to cooperate on the design and improvement of Data Warehouse implementation patterns and ETL generation concepts.

## Why is the top-level object a list?

The convention is that, even though only a single Data Object Mapping may be needed for a transformation or copy, a Data Object Mapping is *always* part of a Data Object Mapping List. So at the top level, one or more Data Object Mappings are always grouped into a single Data Object Mapping List.

In other words, the Data Object Mapping List is an array of individual Data Object Mappings. In code, this means a Data Object Mapping List is defined as a `List<DataObjectMapping>` (`dataObjectMappings`).

The decision to start the format with an array of Data Object Mappings relates to the Data Warehouse virtualisation use-case. Testing has shown it's much harder to piece relationships between mappings together at a later stage in order to create a single (view) object - having the option to define a collection makes this easy.

For example, consider the loading of a Core Business Concept ('Hub') type entity from various different data sources. If you would use these different mappings to generate ETL processes you would create one physical ETL object for each mapping. However, if you are generating a view that represents the target table you would use the collection (list) of mappings to generate separate statements that are 'unioned' in a single view object.

Example: [sampleBasic.json](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema/blob/main/DataSolutionAutomation/Sample_Metadata/sampleBasic.json).

A simplified example of a single Data Object Mapping (with one source, one target, and a single Data Item Mapping):

```json
{
  "dataObjectMappings": [
    {
      "name": "MappingOne",
      "sourceDataObjects": [
        { "name": "TableOneSource" }
      ],
      "targetDataObject": { "name": "TableOneTarget" },
      "dataItemMappings": [
        {
          "sourceDataItems": [ { "name": "ColumnOneSource" } ],
          "targetDataItem":   { "name": "ColumnOneTarget" }
        }
      ]
    }
  ]
}
```

## Why are Data Objects and Data Items defined as arrays when they are used as sources?

This is implemented to facilitate a greater degree of flexibility. Since the application of the metadata is managed in the templates / patterns, it can be useful to be able to map multiple sources to a single target. This way you can select the first one for easier use-cases and use the collection for more complex scenarios.

The downside is that either a loop or array index needs to be used to pinpoint a source, but this only needs to be implemented once.

Example: using Handlebars to get the name of the first source object:

```handlebars
{{sourceDataObjects.0.name}}
```

## How can I use this format to work with the Virtual Data Warehouse (VDW) tool?

The Virtual Data Warehouse tool has been developed to leverage the Data Solution Automation schema. The front-end is generated based on the information made available in this format. All that is needed is to point the 'input' directory to a folder that contains JSON files conforming to the schema definition.

Once this is in place, the code can be generated using the available metadata.

## How can I use this format to work with my own code generator?

The GitHub repository contains a class library, an example project, and a regression testing project.

The easiest way to get started is to copy and modify the example project, or add the `DataSolutionAutomation.dll` library to your solution. This library contains the various classes required to deserialise ('load') JSON files conforming to the schema into memory for further use.

A simple C# example to generate some quick ETL (taken from the example project):

```cs
// Load a template (pattern) from file
stringTemplate = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"..\..\TemplateSampleBasic.handlebars");

// Compile the template
var template = Handlebars.Compile(stringTemplate);

// Load a metadata Json file into memory as a string
jsonInput = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"..\..\sampleBasic.json");

// Map the Json to the Data Solution Automation classes
deserialisedMapping = JsonConvert.DeserializeObject<DataObjectMappings>(jsonInput);

// Generate the code by merging the metadata with the pattern
result = template(deserialisedMapping);

// Display the result
Console.WriteLine(result);
```
