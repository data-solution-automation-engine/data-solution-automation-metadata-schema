using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

using DataSolutionAutomation.Utils;

using HandlebarsDotNet;

namespace Example_Handlebars;

class Program
{
    static int Main(string[] args)
    {
        HandlebarsHelpers.RegisterHandlebarsHelpers();

        var sampleTemplateDirectory = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\Sample_Templates\";
        var sampleMetadataDirectory = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\Sample_Metadata\";

        var cases = new (string template, string metadata)[]
        {
            ("myFirstTemplate.handlebars",                            "myFirstMapping.json"),
            ("TemplateSampleBasic.handlebars",                        "sampleBasic.json"),
            ("TemplateSampleBasicWithExtensions.handlebars",          "sampleBasicWithExtensions.json"),
            ("TemplateSampleMultipleDataItemMappings.handlebars",     "sampleMultipleDataItemMappings.json"),
            ("TemplateSampleSourceQuery.handlebars",                  "sampleSourceQuery.json"),
            ("TemplateSampleSimpleDDL.handlebars",                    "sampleSimpleDDL.json"),
            ("TemplateSampleCalculation.handlebars",                  "sampleCalculation.json"),
            ("TemplateSampleFreeForm.handlebars",                     "sampleFreeForm.json"),
            ("TemplateSampleCustomFunctions.handlebars",              "sampleCustomFunctions.json"),
        };

        var failed = 0;
        foreach (var c in cases)
        {
            var ok = DisplayPatternResult(sampleTemplateDirectory + c.template, sampleMetadataDirectory + c.metadata);
            if (!ok) failed++;
        }

        Console.WriteLine();
        Console.WriteLine($"==== Summary: {cases.Length - failed}/{cases.Length} examples succeeded ====");
        return failed;
    }

    private static bool DisplayPatternResult(string patternFile, string jsonMetadataFile)
    {
        Console.WriteLine();
        Console.WriteLine("================================================================");
        Console.WriteLine($"Template: {Path.GetFileName(patternFile)}");
        Console.WriteLine($"Metadata: {Path.GetFileName(jsonMetadataFile)}");
        Console.WriteLine("================================================================");

        try
        {
            string stringTemplate = File.ReadAllText(patternFile);
            var template = Handlebars.Compile(stringTemplate);

            string jsonInput = File.ReadAllText(jsonMetadataFile);
            JsonNode deserializedMapping = JsonSerializer.Deserialize<JsonNode>(jsonInput);

            var result = template(deserializedMapping);
            Console.WriteLine(result);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FAILED: {ex.Message}");
            return false;
        }
    }
}
