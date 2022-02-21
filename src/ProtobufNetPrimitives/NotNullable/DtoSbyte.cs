namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer sbyte data.
/// </summary>
[ProtoContract]
public class DtoSbyte
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoSbyte"/> class.
    /// </summary>
    public DtoSbyte()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoSbyte"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoSbyte(sbyte value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public sbyte Data { get; set; }
}
