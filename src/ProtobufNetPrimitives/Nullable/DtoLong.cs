namespace ProtobufNetPrimitives.Nullable;

/// <summary>
/// The DTO class to transfer long data.
/// </summary>
[ProtoContract]
public class DtoLong
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoLong"/> class.
    /// </summary>
    public DtoLong()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoLong"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoLong(long? value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public long? Data { get; set; }
}
