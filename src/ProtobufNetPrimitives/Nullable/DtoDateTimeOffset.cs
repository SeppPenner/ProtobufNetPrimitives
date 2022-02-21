namespace ProtobufNetPrimitives.Nullable;

/// <summary>
/// The DTO class to transfer DateTimeOffset data.
/// </summary>
[ProtoContract]
public class DtoDateTimeOffset
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoDateTimeOffset"/> class.
    /// </summary>
    public DtoDateTimeOffset()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoDateTimeOffset"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoDateTimeOffset(DateTimeOffset? value)
    {
        this.Data = value?.UtcTicks;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public long? Data { get; set; }

    /// <summary>
    /// Gets the date time offset as UTC timestamp.
    /// </summary>
    [ProtoIgnore]
    public DateTimeOffset? DateTimeOffset => this.Data is null ? null : new(this.Data.Value, TimeSpan.FromHours(0));
}
