namespace ProtobufNetPrimitives.Nullable;

/// <summary>
/// The DTO class to transfer nint data.
/// </summary>
[ProtoContract]
public class DtoNint
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoNint"/> class.
    /// </summary>
    public DtoNint()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoNint"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoNint(nint? value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data. protobuf-net has no serializer for nint, so the value travels as long.
    /// </summary>
    [ProtoMember(1)]
    public long? Data { get; set; }

    /// <summary>
    /// Gets the nint.
    /// </summary>
    [ProtoIgnore]
    public nint? Nint => this.Data is null ? null : (nint)this.Data.Value;
}
