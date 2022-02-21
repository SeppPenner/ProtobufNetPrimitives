namespace ProtobufNetPrimitives.Nullable;

/// <summary>
/// The DTO class to transfer decimal data.
/// </summary>
[ProtoContract]
public class DtoDecimal
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoDecimal"/> class.
    /// </summary>
    public DtoDecimal()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoDecimal"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoDecimal(decimal? value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public decimal? Data { get; set; }
}
