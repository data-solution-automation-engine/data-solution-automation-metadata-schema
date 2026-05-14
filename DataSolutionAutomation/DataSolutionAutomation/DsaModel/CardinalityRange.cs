namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// A min/max range used for one end (from or to) of a <see cref="Cardinality"/>.
/// For example "min": "1", "max": "N" expresses "at least one, possibly many".
/// </summary>
public class CardinalityRange
{
    /// <summary>
    /// The lower bound of the range. Typically "0" or "1".
    /// </summary>
    [JsonPropertyName("min")]
    public string? Min { get; set; }

    /// <summary>
    /// The upper bound of the range. Typically "1" or "N".
    /// </summary>
    [JsonPropertyName("max")]
    public string? Max { get; set; }
}
