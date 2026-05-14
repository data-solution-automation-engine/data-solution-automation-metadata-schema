using DataSolutionAutomation.Utils;

namespace DataSolutionAutomation.DsaModel;

/// <summary>
/// <para>The mapping between a source and target data set, table, or file.</para>
/// <para>
/// The DataObjectMapping defines an individual source-to-target mapping (an ETL process).
/// It connects one or more <see cref="DataObject"/> sources to a single <see cref="DataObject"/> target,
/// with <see cref="DataItemMapping"/>s describing the column-to-column transformations.
/// </para>
/// <para>
/// SourceDataObjects, TargetDataObject, and DataItemMappings are the core elements of a DataObjectMapping.
/// </para>
/// </summary>
public class DataObjectMapping
{
    #region Properties
    /// <summary>
    /// An optional unique identifier for the Data Object Mapping.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the Data Object Mapping. Ideally a unique name that identifies the individual mapping.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Name { get; set; } = "NewDataMappingName";

    /// <summary>
    /// The source object(s) of the mapping. Potentially multiple source objects can be mapped to a single target object.
    /// </summary>
    [JsonPropertyName("sourceDataObjects")]
    public List<DataObject> SourceDataObjects { get; set; } = new();

    /// <summary>
    /// The target object of the mapping.
    /// </summary>
    [JsonPropertyName("targetDataObject")]
    public DataObject TargetDataObject { get; set; } = new DataObject { Name = "newTargetDataObject" };

    /// <summary>
    /// Data Objects related to this mapping for purposes other than the source/target relationship,
    /// for example lookups, merge joins, or lineage.
    /// </summary>
    [JsonPropertyName("relatedDataObjects")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<DataObject>? RelatedDataObjects { get; set; }

    /// <summary>
    /// Relationships defined on the mapping (parent/child, foreign keys, lookups, etc.).
    /// </summary>
    [JsonPropertyName("relationships")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<Relationship>? Relationships { get; set; }

    /// <summary>
    /// The collection of Data Items specifically associated with this Data Object Mapping,
    /// used as sources or targets in the mapping or its business key component mappings.
    /// </summary>
    [JsonPropertyName("dataItems")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<DataItem>? DataItems { get; set; }

    /// <summary>
    /// The collection of individual attribute (column or query) mappings.
    /// </summary>
    [JsonPropertyName("dataItemMappings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<DataItemMapping>? DataItemMappings { get; set; }

    /// <summary>
    /// The definition of the Business Key(s) for the Data Object Mapping.
    /// </summary>
    [JsonPropertyName("businessKeyDefinitions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<BusinessKeyDefinition>? BusinessKeyDefinitions { get; set; }

    /// <summary>
    /// Any filtering that needs to be applied to the source-to-target mapping.
    /// </summary>
    [JsonPropertyName("filterCriterion")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? FilterCriterion { get; set; }

    /// <summary>
    /// An indicator which can capture enabling / disabling of an individual source-to-target mapping.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Free-form and optional classification for the mapping for use in data logistics generation logic (evaluation).
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
    /// The collection of template references that apply to this Data Object Mapping.
    /// </summary>
    [JsonPropertyName("templateMappings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<TemplateMapping>? TemplateMappings { get; set; }

    /// <summary>
    /// Free-format notes on the Data Object Mapping.
    /// </summary>
    [JsonPropertyName("notes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Notes { get; set; }
    #endregion

    #region Json Representation
    /// <summary>
    /// Get the standard JSON representation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public string Json => JsonSerializer.Serialize(this, DefaultJsonOptions.SerializerOptions);
    #endregion

    #region Methods
    /// <summary>
    /// Use this method to assert if two Data Object Mappings are the same, based on their Ids.
    /// </summary>
    public override bool Equals(object? obj)
    {
        var other = obj as DataObjectMapping;
        return other?.Id == Id;
    }

    /// <summary>
    /// Override to get a hash value that represents the identifier.
    /// </summary>
    public override int GetHashCode() => (Id?.GetHashCode()) ?? 0;

    /// <summary>
    /// Returns the Name of the Data Object Mapping.
    /// </summary>
    public override string ToString() => Name;
    #endregion
}
