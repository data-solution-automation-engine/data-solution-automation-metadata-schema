namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// A free form key/value pair addition that can contain additional context.
/// </summary>
public class Extension
{
    /// <summary>
    /// The Key in a Key/Value pair.
    /// </summary>
    [JsonPropertyName("key")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string Key { get; set; } = "NewExtension";

    /// <summary>
    /// The Value in a Key/Value pair.
    /// </summary>
    [JsonPropertyName("value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Value { get; set; }

    /// <summary>
    /// Any additional, optional, information to explain the intent of extension key/value pair.
    /// </summary>
    [JsonPropertyName("notes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Notes { get; set; }
}
