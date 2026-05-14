namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// An individual component of a <see cref="BusinessKeyDefinition"/>.
/// A business key is composed of one or more components, each referencing a Data Item.
/// The ordinal position records the order of the components within the business key, which can be meaningful.
/// </summary>
public class BusinessKeyComponent
{
    /// <summary>
    /// The position of this component within the parent business key definition.
    /// </summary>
    [JsonPropertyName("ordinalPosition")]
    public int OrdinalPosition { get; set; }

    /// <summary>
    /// The Data Item that forms this component of the business key.
    /// </summary>
    [JsonPropertyName("dataItem")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DataItem? DataItem { get; set; }
}
