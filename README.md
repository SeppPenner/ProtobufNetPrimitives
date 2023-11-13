ProtobufNetPrimitives
====================================

ProtobufNetPrimitives is a library to transfer basic data types with [protobuf-net.Grpc](https://github.com/protobuf-net/protobuf-net.Grpc).

[![Build status](https://ci.appveyor.com/api/projects/status/q89qcgvtb45fcri0?svg=true)](https://ci.appveyor.com/project/SeppPenner/protobufnetprimitives)
[![GitHub issues](https://img.shields.io/github/issues/SeppPenner/ProtobufNetPrimitives.svg)](https://github.com/SeppPenner/ProtobufNetPrimitives/issues)
[![GitHub forks](https://img.shields.io/github/forks/SeppPenner/ProtobufNetPrimitives.svg)](https://github.com/SeppPenner/ProtobufNetPrimitives/network)
[![GitHub stars](https://img.shields.io/github/stars/SeppPenner/ProtobufNetPrimitives.svg)](https://github.com/SeppPenner/ProtobufNetPrimitives/stargazers)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://raw.githubusercontent.com/SeppPenner/ProtobufNetPrimitives/master/License.txt)
[![Nuget](https://img.shields.io/badge/ProtobufNetPrimitives-Nuget-brightgreen.svg)](https://www.nuget.org/packages/HaemmerElectronics.SeppPenner.ProtobufNetPrimitives/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/HaemmerElectronics.SeppPenner.ProtobufNetPrimitives.svg)](https://www.nuget.org/packages/HaemmerElectronics.SeppPenner.ProtobufNetPrimitives/)
[![Known Vulnerabilities](https://snyk.io/test/github/SeppPenner/ProtobufNetPrimitives/badge.svg)](https://snyk.io/test/github/SeppPenner/ProtobufNetPrimitives)
[![Gitter](https://badges.gitter.im/ProtobufNetPrimitives/community.svg)](https://gitter.im/ProtobufNetPrimitives/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

## Available for
* Net 6.0
* Net 7.0

## Net Core and Net Framework latest and LTS versions
* https://dotnet.microsoft.com/download/dotnet

## Available data types

|Net type|GRPC type|Remark|
|-|-|-|
|`bool`|`DtoBool`|-|
|`byte`|`DtoByte`|-|
|`char`|`DtoChar`|-|
|`DateTime`|`DtoDateTime`|The value is internally stored as long, use the property `DateTime` to get the correct value.|
|`DateTimeOffset`|`DtoDateTimeOffset`|The value is internally stored as long, use the property `DateTimeOffset` to get the correct value.|
|`decimal`|`DtoDecimal`|-|
|`double`|`DtoDouble`|-|
|`float`|`DtoFloat`|-|
|`Guid`|`DtoGuid`|The value is internally stored as string, use the property `Uuid` to get the correct value.|
|`int`|`DtoInt`|-|
|`long`|`DtoLong`|-|
|`nint`|`DtoNint`|-|
|`nuint`|`DtoNuint`|-|
|`sbyte`|`DtoSbyte`|-|
|`short`|`DtoShort`|-|
|`string`|`DtoString`|-|
|`TimeSpan`|`DtoTimeSpan`|The value is internally stored as long, use the property `TimeSpan` to get the correct value.|
|`uint`|`DtoUint`|-|
|`ulong`|`DtoUlong`|-|
|`ushort`|`DtoUshort`|-|

Non-Nullable and Nullable types are supported (Different sub-namespaces).

# Why you can't use generics here

```csharp
/// <summary>
/// The base DTO class.
/// </summary>
[ProtoContract]
[ProtoInclude(1, typeof(DtoBool))]
public class DtoBase<T> where T : new()
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoBase{T}"/> class.
    /// </summary>
    public DtoBase()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoBase{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoBase(T value)
    {
        this.Data = value;
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    [ProtoMember(2)]
    public T Data { get; set; } = new();
}

/// <summary>
/// The DTO class to transfer bool data.
/// </summary>
[ProtoContract]
public class DtoBool : DtoBase<bool>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DtoBool"/> class.
    /// </summary>
    public DtoBool()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DtoBool"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public DtoBool(bool value)
    {
        this.Data = value;
    }
}
```

throws the error subscribed under https://github.com/protobuf-net/protobuf-net/issues/829 (Not resolved yet).

## Install

```bash
dotnet add package HaemmerElectronics.SeppPenner.ProtobufNetPrimitives
```

Change history
--------------

See the [Changelog](https://github.com/SeppPenner/ProtobufNetPrimitives/blob/master/Changelog.md).