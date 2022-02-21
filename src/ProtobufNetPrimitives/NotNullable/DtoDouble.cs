namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer double data.
/// </summary>
[ProtoContract]
public class DtoDouble
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoDouble"/> class.
    /// </summary>
    public DtoDouble()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoDouble"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoDouble(double value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public double Data { get; set; }
}
