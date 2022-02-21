namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer byte data.
/// </summary>
[ProtoContract]
public class DtoByte
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoByte"/> class.
    /// </summary>
    public DtoByte()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoByte"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoByte(byte value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public byte Data { get; set; }
}
