namespace ProtobufNetPrimitives.NotNullable;

/// <summary>
/// The DTO class to transfer float data.
/// </summary>
[ProtoContract]
public class DtoFloat
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoFloat"/> class.
    /// </summary>
    public DtoFloat()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoFloat"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoFloat(float value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public float Data { get; set; }
}
