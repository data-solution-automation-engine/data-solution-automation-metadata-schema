namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// A business key definition is a special object that is defined as an optional property of a data object mapping.
/// It captures how a business key is composed from one or more <see cref="BusinessKeyComponent"/>s,
/// each referencing a Data Item.
/// </summary>
public class BusinessKeyDefinition
{
    /// <summary>
    /// Optional identifier as a string value to allow various identifier approaches.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Id { get; set; }

    /// <summary>
    /// The optional name of the business key definition.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Name { get; set; }

    /// <summary>
    /// The ordinal position of this business key definition within its parent mapping.
    /// Relevant for Link objects that have multiple business keys (one per Hub).
    /// </summary>
    [JsonPropertyName("ordinalPosition")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int OrdinalPosition { get; set; }

    /// <summary>
    /// The components of the business key. The order of components is meaningful and is recorded on each component.
    /// </summary>
    [JsonPropertyName("businessKeyComponents")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<BusinessKeyComponent>? BusinessKeyComponents { get; set; }

    /// <summary>
    /// Legacy pre-v2.1 representation of business key components as Data Item Mappings.
    /// Retained for backward-compatible reading of older metadata files; new files should use <see cref="BusinessKeyComponents"/>.
    /// </summary>
    [JsonPropertyName("businessKeyComponentMappings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<DataItemMapping>? BusinessKeyComponentMappings { get; set; }

    /// <summary>
    /// An optional label for the end result e.g. the target business key attribute.
    /// </summary>
    [JsonPropertyName("surrogateKey")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? SurrogateKey { get; set; }

    /// <summary>
    /// Free-form and optional classification for the business key for use in generation logic (evaluation).
    /// </summary>
    [JsonPropertyName("classifications")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<DataClassification>? Classifications { get; set; }

    /// <summary>
    /// The collection of extension key/value pairs.
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
}
