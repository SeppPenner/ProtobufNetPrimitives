namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer TimeSpan data.
/// </summary>
[ProtoContract]
public class DtoTimeSpan
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoTimeSpan"/> class.
    /// </summary>
    public DtoTimeSpan()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoTimeSpan"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoTimeSpan(TimeSpan value)
    {
        this.Data = value.Ticks;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public long Data { get; set; }

    /// <summary>
    /// Gets the time span.
    /// </summary>
    [ProtoIgnore]
    public TimeSpan TimeSpan => new(this.Data);
}
