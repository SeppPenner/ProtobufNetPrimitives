namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer nuint data.
/// </summary>
[ProtoContract]
public class DtoNuint
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoNuint"/> class.
    /// </summary>
    public DtoNuint()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoNuint"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoNuint(nuint value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data. protobuf-net has no serializer for nuint, so the value travels as ulong.
    /// </summary>
    [ProtoMember(1)]
    public ulong Data { get; set; }

    /// <summary>
    /// Gets the nuint.
    /// </summary>
    [ProtoIgnore]
    public nuint Nuint => (nuint)this.Data;
}
