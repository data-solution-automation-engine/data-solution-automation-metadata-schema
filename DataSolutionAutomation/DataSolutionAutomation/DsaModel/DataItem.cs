namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// Data items belong to data objects. They describe the individual elements, such as the columns in a table or headers in a file.
/// A Data Item can also represent a query expression (a calculated column) by setting <see cref="QueryCode"/> and optionally <see cref="QueryLanguage"/>.
/// </summary>
public class DataItem
{
    /// <summary>
    /// Identifier as a string value to allow various identifier approaches.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Id { get; set; }

    /// <summary>
    /// The mandatory name of the Data Item.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Name { get; set; } = "NewDataItem";

    /// <summary>
    /// The data type of the Data Item (e.g. VARCHAR, int, text).
    /// </summary>
    [JsonPropertyName("dataType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? DataType { get; set; }

    /// <summary>
    /// The character length for text-typed Data Items.
    /// </summary>
    [JsonPropertyName("characterLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? CharacterLength { get; set; }

    /// <summary>
    /// The numeric precision (total digits).
    /// </summary>
    [JsonPropertyName("numericPrecision")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? NumericPrecision { get; set; }

    /// <summary>
    /// The numeric scale (digits to the right of the decimal point).
    /// </summary>
    [JsonPropertyName("numericScale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? NumericScale { get; set; }

    /// <summary>
    /// The ordinal position of this item within its parent Data Object.
    /// </summary>
    [JsonPropertyName("ordinalPosition")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? OrdinalPosition { get; set; }

    /// <summary>
    /// Indicates whether this item is part of a Primary Key.
    /// </summary>
    [JsonPropertyName("isPrimaryKey")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? IsPrimaryKey { get; set; }

    /// <summary>
    /// Indicates whether this item accepts null values.
    /// </summary>
    [JsonPropertyName("isNullable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? IsNullable { get; set; }

    /// <summary>
    /// When set, the Data Item represents a query expression (a calculated column) rather than a stored column.
    /// </summary>
    [JsonPropertyName("queryCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? QueryCode { get; set; }

    /// <summary>
    /// The language that <see cref="QueryCode"/> is written in (e.g. SQL).
    /// </summary>
    [JsonPropertyName("queryLanguage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? QueryLanguage { get; set; }

    /// <summary>
    /// Free-form and optional classification for the Data Item for use in generation logic (evaluation).
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
    /// Use this method to assert if two Data Items are the same, based on their Ids.
    /// </summary>
    public override bool Equals(object? obj)
    {
        var other = obj as DataItem;
        return other?.Id == Id;
    }

    /// <summary>
    /// Override to get a hash value that represents the identifier.
    /// </summary>
    public override int GetHashCode() => (Id?.GetHashCode()) ?? 0;

    /// <summary>
    /// Returns the Name of the Data Item.
    /// </summary>
    public override string ToString() => Name;
    #endregion
}
