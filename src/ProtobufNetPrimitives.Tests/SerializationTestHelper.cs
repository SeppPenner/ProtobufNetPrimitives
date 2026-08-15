namespace ProtobufNetPrimitives.Tests;

/// <summary>
/// A helper class to send a DTO through protobuf-net and back, which is the only thing the DTOs of this library
/// are built for.
/// </summary>
internal static class SerializationTestHelper
{
    /// <summary>
    /// Serializes the given DTO with protobuf-net and deserializes it again.
    /// </summary>
    /// <typeparam name="T">The type of the DTO.</typeparam>
    /// <param name="value">The DTO to send through protobuf-net.</param>
    /// <returns>The deserialized DTO.</returns>
    internal static T Roundtrip<T>(T value)
    {
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, value);
        stream.Position = 0;
        return Serializer.Deserialize<T>(stream);
    }
}
