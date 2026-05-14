namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// A relationship from one Data Object to another.
/// This can apply at conceptual, logical, and physical levels.
/// Supports lineage relationships (e.g. parent/child), foreign keys, and sub/supertypes.
/// </summary>
public class Relationship
{
    #region Properties
    /// <summary>
    /// An optional identifier for the relationship.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// The mandatory name of the relationship.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; } = string.Empty;

    /// <summary>
    /// The type of relationship. Free-format label, for example "parent", "child", or "lookup".
    /// </summary>
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Type { get; set; }

    /// <summary>
    /// Cardinality of the relationship, expressed as min/max ranges on each end.
    /// Supports forms like "0 or 1 to many", "1 (and only one) to 1", "zero or many to one", etc.
    /// </summary>
    [JsonPropertyName("cardinality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Cardinality? Cardinality { get; set; }

    /// <summary>
    /// Identifier-only reference to the related Data Object.
    /// Use this when the related object lives elsewhere in the file and should not be embedded.
    /// </summary>
    [JsonPropertyName("relatedDataObjectId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? RelatedDataObjectId { get; set; }

    /// <summary>
    /// The related Data Object, embedded.
    /// Used when the JSON contains the full object rather than just an ID reference.
    /// </summary>
    [JsonPropertyName("relatedDataObject")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DataObject? RelatedDataObject { get; set; }

    /// <summary>
    /// The Data Item mappings for foreign-key style relationships, expressed as lightweight identifier references.
    /// </summary>
    [JsonPropertyName("dataItemMappings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<DataItemMappingRef>? DataItemMappings { get; set; }

    /// <summary>
    /// Free-form and optional classification for the relationship.
    /// </summary>
    [JsonPropertyName("classifications")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<DataClassification>? Classifications { get; set; }

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
    #endregion

    #region Methods
    /// <summary>
    /// Used to assert whether two Relationships are the same, based on their Ids.
    /// </summary>
    public override bool Equals(object? obj)
    {
        var other = obj as Relationship;
        return other?.Id == Id;
    }

    /// <summary>
    /// Generates a Hash Code derived from the Id.
    /// </summary>
    public override int GetHashCode() => Id?.GetHashCode() ?? 0;

    /// <summary>
    /// Returns the Name of the relationship.
    /// </summary>
    public override string ToString() => Name ?? string.Empty;
    #endregion
}
