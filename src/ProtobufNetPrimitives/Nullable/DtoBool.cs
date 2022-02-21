namespace ProtobufNetPrimitives.Nullable;

/// <summary>
/// The DTO class to transfer bool data.
/// </summary>
[ProtoContract]
public class DtoBool
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoBool"/> class.
    /// </summary>
    public DtoBool()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoBool"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoBool(bool? value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public bool? Data { get; set; }
}
