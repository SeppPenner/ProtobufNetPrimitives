namespace ProtobufNetPrimitives.Tests;

/// <summary>
/// A class to test the DTO classes of the ProtobufNetPrimitives.NotNullable namespace.
/// </summary>
[TestClass]
public class NotNullableDtoTests
{
    /// <summary>
    /// Checks whether a bool survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoBoolRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoBool(true));

        Assert.IsTrue(result.Data);
    }

    /// <summary>
    /// Checks whether a byte survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoByteRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoByte(byte.MaxValue));

        Assert.AreEqual(byte.MaxValue, result.Data);
    }

    /// <summary>
    /// Checks whether a char survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoCharRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoChar('ä'));

        Assert.AreEqual('ä', result.Data);
    }

    /// <summary>
    /// Checks whether a <see cref="DateTime"/> survives the protobuf-net roundtrip. The value travels as ticks,
    /// so the roundtrip is compared on the ticks and on the property that rebuilds the date.
    /// </summary>
    [TestMethod]
    public void DtoDateTimeRoundtripsTheValue()
    {
        var value = new DateTime(2026, 8, 15, 12, 34, 56, DateTimeKind.Utc);

        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoDateTime(value));

        Assert.AreEqual(value.Ticks, result.Data);
        Assert.AreEqual(value.Ticks, result.DateTime.Ticks);
    }

    /// <summary>
    /// Checks whether the <see cref="DateTimeKind"/> is lost, because only the ticks are transferred. The
    /// rebuilt date is therefore always <see cref="DateTimeKind.Unspecified"/>, no matter what went in.
    /// </summary>
    [TestMethod]
    public void DtoDateTimeLosesTheDateTimeKind()
    {
        var value = new DateTime(2026, 8, 15, 12, 34, 56, DateTimeKind.Utc);

        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoDateTime(value));

        Assert.AreEqual(DateTimeKind.Unspecified, result.DateTime.Kind);
    }

    /// <summary>
    /// Checks whether a <see cref="DateTimeOffset"/> survives the protobuf-net roundtrip as the same point in
    /// time.
    /// </summary>
    [TestMethod]
    public void DtoDateTimeOffsetRoundtripsTheValue()
    {
        var value = new DateTimeOffset(2026, 8, 15, 12, 34, 56, TimeSpan.FromHours(2));

        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoDateTimeOffset(value));

        Assert.AreEqual(value.UtcTicks, result.Data);
        Assert.AreEqual(value, result.DateTimeOffset);
    }

    /// <summary>
    /// Checks whether the offset itself is lost, because only the UTC ticks are transferred. The rebuilt value
    /// describes the same point in time, but always with the offset zero.
    /// </summary>
    [TestMethod]
    public void DtoDateTimeOffsetLosesTheOffset()
    {
        var value = new DateTimeOffset(2026, 8, 15, 12, 34, 56, TimeSpan.FromHours(2));

        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoDateTimeOffset(value));

        Assert.AreEqual(TimeSpan.Zero, result.DateTimeOffset.Offset);
        Assert.AreEqual(10, result.DateTimeOffset.Hour);
    }

    /// <summary>
    /// Checks whether a decimal survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoDecimalRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoDecimal(1234.5678m));

        Assert.AreEqual(1234.5678m, result.Data);
    }

    /// <summary>
    /// Checks whether a double survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoDoubleRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoDouble(double.MaxValue));

        Assert.AreEqual(double.MaxValue, result.Data);
    }

    /// <summary>
    /// Checks whether a float survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoFloatRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoFloat(float.MaxValue));

        Assert.AreEqual(float.MaxValue, result.Data);
    }

    /// <summary>
    /// Checks whether a <see cref="Guid"/> survives the protobuf-net roundtrip. It travels as its string
    /// representation, so both the string and the rebuilt <see cref="Guid"/> are checked.
    /// </summary>
    [TestMethod]
    public void DtoGuidRoundtripsTheValue()
    {
        var value = new Guid("11111111-2222-3333-4444-555555555555");

        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoGuid(value));

        Assert.AreEqual(value.ToString(), result.Data);
        Assert.AreEqual(value, result.Uuid);
    }

    /// <summary>
    /// Checks whether the Uuid property throws on a default instance. The data of a default instance is the
    /// empty string, which is no valid <see cref="Guid"/>, and that is exactly what an instance deserialized
    /// from an empty message looks like.
    /// </summary>
    [TestMethod]
    public void DtoGuidThrowsOnADefaultInstance()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoGuid());

        Assert.AreEqual(string.Empty, result.Data);
        Assert.ThrowsExactly<FormatException>(() => _ = result.Uuid);
    }

    /// <summary>
    /// Checks whether an int survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoIntRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoInt(int.MinValue));

        Assert.AreEqual(int.MinValue, result.Data);
    }

    /// <summary>
    /// Checks whether a long survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoLongRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoLong(long.MinValue));

        Assert.AreEqual(long.MinValue, result.Data);
    }

    /// <summary>
    /// Checks whether an nint survives the protobuf-net roundtrip. The value travels as long, because
    /// protobuf-net has no serializer for nint.
    /// </summary>
    [TestMethod]
    public void DtoNintRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoNint(42));

        Assert.AreEqual(42L, result.Data);
        Assert.AreEqual(42, result.Nint);
    }

    /// <summary>
    /// Checks whether an nuint survives the protobuf-net roundtrip. The value travels as ulong, because
    /// protobuf-net has no serializer for nuint.
    /// </summary>
    [TestMethod]
    public void DtoNuintRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoNuint(42));

        Assert.AreEqual(42UL, result.Data);
        Assert.AreEqual((nuint)42, result.Nuint);
    }

    /// <summary>
    /// Checks whether an sbyte survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoSbyteRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoSbyte(sbyte.MinValue));

        Assert.AreEqual(sbyte.MinValue, result.Data);
    }

    /// <summary>
    /// Checks whether a short survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoShortRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoShort(short.MinValue));

        Assert.AreEqual(short.MinValue, result.Data);
    }

    /// <summary>
    /// Checks whether a string survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoStringRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoString("Hämmer Electronics"));

        Assert.AreEqual("Hämmer Electronics", result.Data);
    }

    /// <summary>
    /// Checks whether the string of a default instance is the empty string and not a null reference, which is
    /// what the non nullable variant promises.
    /// </summary>
    [TestMethod]
    public void DtoStringOfADefaultInstanceIsTheEmptyString()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoString());

        Assert.AreEqual(string.Empty, result.Data);
    }

    /// <summary>
    /// Checks whether a <see cref="TimeSpan"/> survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoTimeSpanRoundtripsTheValue()
    {
        var value = TimeSpan.FromMinutes(90);

        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoTimeSpan(value));

        Assert.AreEqual(value.Ticks, result.Data);
        Assert.AreEqual(value, result.TimeSpan);
    }

    /// <summary>
    /// Checks whether an uint survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoUintRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoUint(uint.MaxValue));

        Assert.AreEqual(uint.MaxValue, result.Data);
    }

    /// <summary>
    /// Checks whether an ulong survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoUlongRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoUlong(ulong.MaxValue));

        Assert.AreEqual(ulong.MaxValue, result.Data);
    }

    /// <summary>
    /// Checks whether an ushort survives the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoUshortRoundtripsTheValue()
    {
        var result = SerializationTestHelper.Roundtrip(new NotNullableDtos.DtoUshort(ushort.MaxValue));

        Assert.AreEqual(ushort.MaxValue, result.Data);
    }
}
