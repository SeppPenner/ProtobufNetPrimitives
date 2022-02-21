namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer short data.
/// </summary>
[ProtoContract]
public class DtoShort
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoShort"/> class.
    /// </summary>
    public DtoShort()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoShort"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoShort(short value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public short Data { get; set; }
}
