namespace ProtobufNetPrimitives.Nullable;

/// <summary>
/// The DTO class to transfer Guid data.
/// </summary>
[ProtoContract]
public class DtoGuid
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoGuid"/> class.
    /// </summary>
    public DtoGuid()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoGuid"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoGuid(Guid? value)
    {
        this.Data = value?.ToString();
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public string? Data { get; set; }

    /// <summary>
    /// Gets the Guid.
    /// </summary>
    [ProtoIgnore]
    public Guid? Uuid => string.IsNullOrWhiteSpace(this.Data) ? null : new(this.Data);
}
