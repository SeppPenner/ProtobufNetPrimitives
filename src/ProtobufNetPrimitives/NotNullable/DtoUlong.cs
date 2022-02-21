namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer ulong data.
/// </summary>
[ProtoContract]
public class DtoUlong
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoUlong"/> class.
    /// </summary>
    public DtoUlong()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoUlong"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoUlong(ulong value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public ulong Data { get; set; }
}
