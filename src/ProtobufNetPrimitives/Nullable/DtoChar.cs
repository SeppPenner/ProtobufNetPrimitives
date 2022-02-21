namespace ProtobufNetPrimitives.Nullable;

/// <summary>
/// The DTO class to transfer char data.
/// </summary>
[ProtoContract]
public class DtoChar
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoChar"/> class.
    /// </summary>
    public DtoChar()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoChar"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoChar(char? value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public char? Data { get; set; }
}
