namespace ProtobufNetPrimitives.Nullable;

/// <summary>
/// The DTO class to transfer uint data.
/// </summary>
[ProtoContract]
public class DtoUint
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoUint"/> class.
    /// </summary>
    public DtoUint()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoUint"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoUint(uint? value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public uint? Data { get; set; }
}
