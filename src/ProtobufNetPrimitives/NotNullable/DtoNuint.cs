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
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public nuint Data { get; set; }
}
