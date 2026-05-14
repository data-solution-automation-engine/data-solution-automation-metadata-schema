namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// The definition of a data set, file, or table.
/// A Data Object can be the source or target in a <see cref="DataObjectMapping"/>.
/// A Data Object can also represent a query (a view, script, or procedure)
/// by setting <see cref="QueryCode"/> and optionally <see cref="QueryLanguage"/>.
/// </summary>
public class DataObject
{
    /// <summary>
    /// An optional identifier for the Data Object.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Id { get; set; }

    /// <summary>
    /// The mandatory name of the Data Object.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = "NewDataObject";

    /// <summary>
    /// The connection information associated with the Data Object.
    /// </summary>
    [JsonPropertyName("dataConnection")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DataConnection? DataConnection { get; set; }

    /// <summary>
    /// The collection of Data Items associated with this Data Object.
    /// </summary>
    [JsonPropertyName("dataItems")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<DataItem>? DataItems { get; set; }

    /// <summary>
    /// When set, the Data Object represents a query (view, script, or procedure) rather than a stored table.
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
    /// The definition of the Business Key(s) for the Data Object.
    /// Capturing the business key definition here supports defining a series of business keys against the source
    /// Data Object and reusing these across different Data Object Mappings.
    /// </summary>
    [JsonPropertyName("businessKeyDefinitions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<BusinessKeyDefinition>? BusinessKeyDefinitions { get; set; }

    /// <summary>
    /// Relationships to other Data Objects (parent/child, foreign keys, lookups, etc.).
    /// </summary>
    [JsonPropertyName("relationships")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<Relationship>? Relationships { get; set; }

    /// <summary>
    /// Free-form and optional classification for the Data Object.
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
    /// The collection of template references that apply to this Data Object.
    /// </summary>
    [JsonPropertyName("templateMappings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<TemplateMapping>? TemplateMappings { get; set; }

    /// <summary>
    /// Free-format notes.
    /// </summary>
    [JsonPropertyName("notes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Notes { get; set; }

    #region Methods
    /// <summary>
    /// Use this method to assert if two Data Objects are the same, based on their Ids.
    /// </summary>
    public override bool Equals(object? obj)
    {
        var other = obj as DataObject;
        return other?.Id == Id;
    }

    /// <summary>
    /// Override to get a hash value that represents the identifier.
    /// </summary>
    public override int GetHashCode() => (Id?.GetHashCode()) ?? 0;

    /// <summary>
    /// Returns the Name of the Data Object.
    /// </summary>
    public override string ToString() => Name;
    #endregion
}
