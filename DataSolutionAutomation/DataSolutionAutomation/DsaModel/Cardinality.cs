namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// Captures the cardinality and ordinality of a relationship.
/// Cardinality defines the number of occurrences of one entity that are associated with the number of occurrences of another entity through a relationship.
/// </summary>
public class Cardinality
{
    /// <summary>
    /// Optional identifier as a string value to allow various identifier approaches.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Id { get; set; }

    /// <summary>
    /// Optional name for a recognised cardinality construct,
    /// for example "one-to-one", "one-to-many", or "many-to-many".
    /// E.g. one-to-one corresponds to {"fromRange": {"min": "1", "max": "1"}, "toRange": {"min": "1", "max": "1"}}.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Name { get; set; }

    /// <summary>
    /// The 'from' component of the cardinality (e.g. the '1' in 1-to-many).
    /// </summary>
    [JsonPropertyName("fromRange")]
    public CardinalityRange? FromRange { get; set; } = new CardinalityRange { Min = "1", Max = "1" };

    /// <summary>
    /// The 'to' component of the cardinality (e.g. the 'many' in 1-to-many).
    /// </summary>
    [JsonPropertyName("toRange")]
    public CardinalityRange? ToRange { get; set; } = new CardinalityRange { Min = "1", Max = "N" };

    /// <summary>
    /// Free-form and optional classification for the Cardinality for use in generation logic (evaluation).
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

    #region Methods
    /// <summary>
    /// Use this method to assert if two Cardinalities are the same, based on their Ids.
    /// </summary>
    public override bool Equals(object? obj)
    {
        var other = obj as Cardinality;
        return other?.Id == Id;
    }

    /// <summary>
    /// Override to get a hash value that represents the identifier.
    /// </summary>
    public override int GetHashCode() => (Id?.GetHashCode()) ?? 0;

    /// <summary>
    /// Returns the Name of the Cardinality.
    /// </summary>
    public override string ToString() => Name ?? string.Empty;
    #endregion
}
