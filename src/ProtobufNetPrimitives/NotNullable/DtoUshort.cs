namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer ushort data.
/// </summary>
[ProtoContract]
public class DtoUshort
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoUshort"/> class.
    /// </summary>
    public DtoUshort()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoUshort"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoUshort(ushort value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public ushort Data { get; set; }
}
