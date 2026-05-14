namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// A reference to a template file that should be applied to the parent object.
/// Template mappings let metadata travel together with the templates used to generate code from it.
/// </summary>
public class TemplateMapping
{
    /// <summary>
    /// The file name of the template to apply.
    /// </summary>
    [JsonPropertyName("templateFileName")]
    public string TemplateFileName { get; set; } = string.Empty;
}
