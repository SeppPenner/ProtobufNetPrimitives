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
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public nint? Data { get; set; }
}
