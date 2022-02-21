namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer DateTime data.
/// </summary>
[ProtoContract]
public class DtoDateTime
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoDateTime"/> class.
    /// </summary>
    public DtoDateTime()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoDateTime"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoDateTime(DateTime value)
    {
        this.Data = value.Ticks;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public long Data { get; set; }

    /// <summary>
    /// Gets the date time.
    /// </summary>
    [ProtoIgnore]
    public DateTime DateTime => new(this.Data);
}
