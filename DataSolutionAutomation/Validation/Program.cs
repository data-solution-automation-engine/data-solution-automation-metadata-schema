using System;
using System.Collections.Generic;

using DataSolutionAutomation.Utils;

namespace Test_Project;

internal sealed class Program
{
    static int Main(string[] args)
    {
        var jsonSchema = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\GenericInterface\interfaceDataSolutionAutomationMetadataV2_1.json";
        var sampleTemplateDirectory = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\Sample_Metadata\";

        // Samples expected to be valid against V2_1.
        // The older-format files (sampleBasicWithExtensions, sampleCustomFunctions, myFirstMapping) are
        // intentionally kept as fixtures for the SchemaJsonConverter migration tool and validate against V2_0.
        // sampleFreeForm is intentionally non-conformant.
        List<string> fileList =
        [
            sampleTemplateDirectory + "sampleBasic.json",
            sampleTemplateDirectory + "sampleSourceQuery.json",
            sampleTemplateDirectory + "sampleCalculation.json",
            sampleTemplateDirectory + "sampleMultipleDataItemMappings.json",
            sampleTemplateDirectory + "sampleSimpleDDL.json",
        ];

        var hadFailures = false;
        foreach (var jsonFile in fileList)
        {
            var result = JsonValidation.ValidateJsonFileAgainstSchema(jsonSchema, jsonFile);
            var testOutput = result.Valid ? "OK" : "FAILED";
            Console.WriteLine($"{testOutput}: {System.IO.Path.GetFileName(jsonFile)}");

            if (!result.Valid)
            {
                hadFailures = true;
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"   line {error.LineNumber} col {error.LinePosition} ({error.ErrorType}) at {error.Path}: {error.Message}");
                }
            }
        }

        return hadFailures ? 1 : 0;
    }
}
