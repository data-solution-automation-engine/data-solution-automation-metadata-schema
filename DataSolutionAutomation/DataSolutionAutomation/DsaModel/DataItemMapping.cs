namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// The individual column-to-column mapping between source and target Data Items.
/// </summary>
public class DataItemMapping
{
    /// <summary>
    /// Optional identifier as a string value to allow various identifier approaches.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Id { get; set; }

    /// <summary>
    /// Optional name for the Data Item Mapping.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Name { get; set; }

    /// <summary>
    /// The source Data Items of the mapping.
    /// </summary>
    [JsonPropertyName("sourceDataItems")]
    public List<DataItem> SourceDataItems { get; set; } = [];

    /// <summary>
    /// The target Data Item of the mapping.
    /// </summary>
    [JsonPropertyName("targetDataItem")]
    public DataItem TargetDataItem { get; set; } = new DataItem { Name = "newTargetDataItem" };

    /// <summary>
    /// The collection of extension Key/Value pairs.
    /// </summary>
    [JsonPropertyName("extensions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<Extension>? Extensions { get; set; }

    /// <summary>
    /// Free-format notes.
    /// </summary>
    [JsonPropertyName("notes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Notes { get; set; }

    #region Methods
    /// <summary>
    /// Use this method to assert if two DataItemMappings are the same, based on their Ids.
    /// </summary>
    public override bool Equals(object? obj)
    {
        var other = obj as DataItemMapping;
        return other?.Id == Id;
    }

    /// <summary>
    /// Override to get a hash value that represents the identifier.
    /// </summary>
    public override int GetHashCode() => (Id?.GetHashCode()) ?? 0;

    /// <summary>
    /// Returns the Name of the target Data Item.
    /// </summary>
    public override string ToString() => TargetDataItem.Name;
    #endregion
}
