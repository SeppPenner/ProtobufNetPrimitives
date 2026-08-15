namespace ProtobufNetPrimitives.Tests;

/// <summary>
/// A class to test the DTO classes of the ProtobufNetPrimitives.Nullable namespace. Every type is checked twice,
/// once with a value and once with null, because null is the whole point of this namespace.
/// </summary>
[TestClass]
public class NullableDtoTests
{
    /// <summary>
    /// Checks whether a bool and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoBoolRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoBool(true));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoBool(null));

        Assert.AreEqual(true, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether a byte and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoByteRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoByte(byte.MaxValue));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoByte(null));

        Assert.AreEqual(byte.MaxValue, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether a char and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoCharRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoChar('ä'));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoChar(null));

        Assert.AreEqual('ä', result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether a <see cref="DateTime"/> and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoDateTimeRoundtripsTheValueAndNull()
    {
        var value = new DateTime(2026, 8, 15, 12, 34, 56, DateTimeKind.Utc);

        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoDateTime(value));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoDateTime(null));

        Assert.AreEqual(value.Ticks, result.Data);
        Assert.AreEqual(value.Ticks, result.DateTime?.Ticks);
        Assert.IsNull(nullResult.Data);
        Assert.IsNull(nullResult.DateTime);
    }

    /// <summary>
    /// Checks whether a <see cref="DateTimeOffset"/> and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoDateTimeOffsetRoundtripsTheValueAndNull()
    {
        var value = new DateTimeOffset(2026, 8, 15, 12, 34, 56, TimeSpan.FromHours(2));

        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoDateTimeOffset(value));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoDateTimeOffset(null));

        Assert.AreEqual(value.UtcTicks, result.Data);
        Assert.AreEqual(value, result.DateTimeOffset);
        Assert.IsNull(nullResult.Data);
        Assert.IsNull(nullResult.DateTimeOffset);
    }

    /// <summary>
    /// Checks whether a decimal and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoDecimalRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoDecimal(1234.5678m));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoDecimal(null));

        Assert.AreEqual(1234.5678m, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether a double and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoDoubleRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoDouble(double.MaxValue));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoDouble(null));

        Assert.AreEqual(double.MaxValue, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether a float and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoFloatRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoFloat(float.MaxValue));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoFloat(null));

        Assert.AreEqual(float.MaxValue, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether a <see cref="Guid"/> and null survive the protobuf-net roundtrip. Unlike its non nullable
    /// counterpart, the Uuid property answers null instead of throwing when no data arrived.
    /// </summary>
    [TestMethod]
    public void DtoGuidRoundtripsTheValueAndNull()
    {
        var value = new Guid("11111111-2222-3333-4444-555555555555");

        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoGuid(value));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoGuid(null));

        Assert.AreEqual(value.ToString(), result.Data);
        Assert.AreEqual(value, result.Uuid);
        Assert.IsNull(nullResult.Data);
        Assert.IsNull(nullResult.Uuid);
    }

    /// <summary>
    /// Checks whether an int and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoIntRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoInt(int.MinValue));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoInt(null));

        Assert.AreEqual(int.MinValue, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether a long and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoLongRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoLong(long.MinValue));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoLong(null));

        Assert.AreEqual(long.MinValue, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether an nint and null survive the protobuf-net roundtrip. The value travels as long, because
    /// protobuf-net has no serializer for nint.
    /// </summary>
    [TestMethod]
    public void DtoNintRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoNint(42));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoNint(null));

        Assert.AreEqual(42L, result.Data);
        Assert.AreEqual(42, result.Nint);
        Assert.IsNull(nullResult.Data);
        Assert.IsNull(nullResult.Nint);
    }

    /// <summary>
    /// Checks whether an nuint and null survive the protobuf-net roundtrip. The value travels as ulong, because
    /// protobuf-net has no serializer for nuint.
    /// </summary>
    [TestMethod]
    public void DtoNuintRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoNuint(42));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoNuint(null));

        Assert.AreEqual(42UL, result.Data);
        Assert.AreEqual((nuint)42, result.Nuint);
        Assert.IsNull(nullResult.Data);
        Assert.IsNull(nullResult.Nuint);
    }

    /// <summary>
    /// Checks whether an sbyte and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoSbyteRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoSbyte(sbyte.MinValue));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoSbyte(null));

        Assert.AreEqual(sbyte.MinValue, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether a short and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoShortRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoShort(short.MinValue));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoShort(null));

        Assert.AreEqual(short.MinValue, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether a string and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoStringRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoString("Hämmer Electronics"));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoString(null));

        Assert.AreEqual("Hämmer Electronics", result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether a <see cref="TimeSpan"/> and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoTimeSpanRoundtripsTheValueAndNull()
    {
        var value = TimeSpan.FromMinutes(90);

        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoTimeSpan(value));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoTimeSpan(null));

        Assert.AreEqual(value.Ticks, result.Data);
        Assert.AreEqual(value, result.TimeSpan);
        Assert.IsNull(nullResult.Data);
        Assert.IsNull(nullResult.TimeSpan);
    }

    /// <summary>
    /// Checks whether an uint and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoUintRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoUint(uint.MaxValue));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoUint(null));

        Assert.AreEqual(uint.MaxValue, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether an ulong and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoUlongRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoUlong(ulong.MaxValue));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoUlong(null));

        Assert.AreEqual(ulong.MaxValue, result.Data);
        Assert.IsNull(nullResult.Data);
    }

    /// <summary>
    /// Checks whether an ushort and null survive the protobuf-net roundtrip.
    /// </summary>
    [TestMethod]
    public void DtoUshortRoundtripsTheValueAndNull()
    {
        var result = SerializationTestHelper.Roundtrip(new NullableDtos.DtoUshort(ushort.MaxValue));
        var nullResult = SerializationTestHelper.Roundtrip(new NullableDtos.DtoUshort(null));

        Assert.AreEqual(ushort.MaxValue, result.Data);
        Assert.IsNull(nullResult.Data);
    }
}
