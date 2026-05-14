namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// A lightweight, identifier-based variant of <see cref="DataItemMapping"/> for use inside a <see cref="Relationship"/>.
/// Instead of embedding the full source and target Data Items (which already live elsewhere in the mapping),
/// this form references them by Id only - typical for foreign-key style relationships.
/// </summary>
public class DataItemMappingRef
{
    /// <summary>
    /// The identifiers of the source Data Items.
    /// </summary>
    [JsonPropertyName("sourceDataItemIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<string>? SourceDataItemIds { get; set; }

    /// <summary>
    /// The identifier of the target Data Item.
    /// </summary>
    [JsonPropertyName("targetDataItemId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? TargetDataItemId { get; set; }
}
