namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer string data.
/// </summary>
[ProtoContract]
public class DtoString
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoString"/> class.
    /// </summary>
    public DtoString()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoString"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoString(string value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public string Data { get; set; } = string.Empty;
}
