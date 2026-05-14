---
title: Getting started
description: How to use the Data Solution Automation schema in your own code generation work.
sidebar:
  order: 1
---

First and foremost, refer to the [GitHub repository](https://github.com/data-solution-automation-engine/data-solution-automation-metadata-schema) for any work in progress including documentation and discussions. This page provides a brief introduction and helps interested parties to get started generating their own code quickly - but the GitHub should always be the first go-to resource for questions, comments and suggestions.

## How can I use the schema?

The generic Data Solution Automation schema / interface definition ('schema') is at its core a series of definitions of how metadata can be recorded.

In practice, it is a class library (`DataSolutionAutomation.dll`) that can be referred to in projects or solutions, and through which JSON metadata files can be validated and/or loaded into memory for further use.

For example, both TEAM and VDW reference this library to read and write JSON files. In other words, the `DataSolutionAutomation` library is the interface between your code and JSON metadata files conforming to the schema.

A screenshot of the GitHub contents in Visual Studio is provided here. You can see the various defined classes belonging to the `DataSolutionAutomation.dll` library, alongside an `Example_Handlebars` project that demonstrates code generation for different use-cases.

## Generating code

One of the simplest ways to get started is to modify the `Example_Handlebars` project. It uses the `Json.Net` and `Handlebars.Net` NuGet packages, plus the `DataSolutionAutomation.dll` library.

With these three components in place, code can be generated using a simple Console application by pointing the paths to a JSON metadata input file (or files) and to a Handlebars pattern file.

Consider the snippet below, taken from the example project:

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

## Validating JSON files against the schema definition

Examples are provided to validate JSON metadata files against the schema definition. These are located in the `Validation` project in the GitHub repository, and used for regression testing - making sure that inputs and outputs provided by the various tools in the Data Solution Automation ecosystem are correctly formatted.

Validating JSON files against the generic schema is straightforward; a method is provided as part of the `JsonValidation` class included in `DataSolutionAutomation.dll`. Given a filename (including path) for the schema definition as well as a JSON file:

```cs
var result = JsonValidation.ValidateJsonFileAgainstSchema(jsonSchema, jsonFile);

var testOutput = result.Valid ? "OK" : "Failed";

Console.Write($"The result for {jsonFile} was {testOutput}.");
```

## Further reading

- [Fun with code generation - extensions](https://roelantvos.com/blog/fun-with-code-generation-patterns-extensions/)
- [Major improvements to the Data Solution Automation schema definition](https://roelantvos.com/blog/major-improvements-to-the-data-solution-automation-schema-definition/)
- [Interface for Data Solution Automation](https://roelantvos.com/blog/interface-for-data-solution-automation/)
- [A collaboration for a common metadata model](https://roelantvos.com/blog/a-collaboration-for-a-common-metadata-model/)
- [Fun with code generation - multiple sources](https://roelantvos.com/blog/fun-with-code-generation-patterns-multiple-sources/)
- [Fun with code generation - transformations](https://roelantvos.com/blog/fun-with-code-generation-patterns-transformations/)
