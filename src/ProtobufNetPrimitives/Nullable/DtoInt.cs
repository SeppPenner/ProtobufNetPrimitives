namespace ProtobufNetPrimitives.Nullable;

/// <summary>
/// The DTO class to transfer int data.
/// </summary>
[ProtoContract]
public class DtoInt
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoInt"/> class.
    /// </summary>
    public DtoInt()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoInt"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoInt(int? value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(1)]
    public int? Data { get; set; }
}
