# Project rules for Claude

## What this is

ProtobufNetPrimitives is a class library that wraps the C# primitive types in DTO classes so that they can be
sent over the wire with [protobuf-net.Grpc](https://github.com/protobuf-net/protobuf-net.Grpc). A gRPC service
contract cannot return a bare `int`, it needs a message type, and generics do not work either (see the section
in the `README.md` and https://github.com/protobuf-net/protobuf-net/issues/829). Hence one hand written class
per type. The library is published as the NuGet package
`HaemmerElectronics.SeppPenner.ProtobufNetPrimitives`.

One solution `src/ProtobufNetPrimitives.sln` with two projects:

- `src/ProtobufNetPrimitives/ProtobufNetPrimitives.csproj`, the library, `GeneratePackageOnBuild`, multi
  targeted to `net8.0;net10.0`.
- `src/ProtobufNetPrimitives.Tests/ProtobufNetPrimitives.Tests.csproj`, MSTest, single target `net10.0`, added
  in version 1.0.9.0.

Layout inside `src/ProtobufNetPrimitives`:

- `NotNullable/Dto*.cs`: 20 classes, one per type, each holding a non nullable value.
- `Nullable/Dto*.cs`: the same 20 class names in a second namespace, each holding a nullable value.
- `GlobalUsings.cs`: all usings of the project.

Both folders contain the same file names and the same class names, they differ only in the namespace. Every
change to one side belongs on the other side too, that symmetry is the whole design.

The shape of a DTO class is always the same: `[ProtoContract]`, a parameterless constructor, a constructor
taking the value, and a `Data` property with `[ProtoMember(1)]`. Types that protobuf-net cannot serialize
directly get a second, `[ProtoIgnore]` marked property that converts the stored value back
(`DateTime`, `DateTimeOffset`, `TimeSpan`, `Uuid`, `Nint`, `Nuint`). Keep new types in that shape.

Layout inside `src/ProtobufNetPrimitives.Tests`:

- `NotNullableDtoTests.cs` and `NullableDtoTests.cs`: one test per DTO type, each sending an instance through
  protobuf-net and back. The nullable tests check the value and null in the same test method. On top of that a
  few tests pin down behaviour that is easy to break: the lost `DateTimeKind`, the lost offset of
  `DateTimeOffset`, the `FormatException` of a default `DtoGuid` and the empty string of a default `DtoString`.
- `SerializationTestHelper.cs`: the `Roundtrip` method that all tests use. It is the only place that talks to
  `ProtoBuf.Serializer`.
- `GlobalUsings.cs`: all usings of the test project, including the aliases `NotNullableDtos` and
  `NullableDtos`. Without them the two namespaces would collide on every class name, and `Nullable` alone
  would shadow `System.Nullable`.

Repository root: `README.md` (the only user documentation, with the type table), `Changelog.md`,
`Updating.md` (the five step release note), `License.txt` (MIT), `Icon.png` (the package icon),
`BuildAndPushPackage.bat`, `Delete-BIN-OBJ-Folders.bat`, `.editorconfig` in `src` and `.gitattributes`.
There is no `HowToUse.md` and no screenshots.

## Build

```powershell
dotnet build src/ProtobufNetPrimitives.sln -c Release
```

```powershell
dotnet test src/ProtobufNetPrimitives.sln
```

- The library multi targets `net8.0;net10.0`. Net 9.0 was dropped in version 1.0.9.0 because it is out of
  support. The test project targets `net10.0` only, there is no Net 8.0 runtime on this machine.
- `src/Directory.Build.props` sets nothing but `GenerateDocumentationFile`. Everything else lives in the two
  `.csproj` files.
- `TreatWarningsAsErrors` is enabled in both projects, so every warning breaks the build, NuGet warnings
  (`NU****`) from restore included. A clean build reports zero warnings, keep it that way.
- `NU1803` (HTTP source usage during restore) is the one warning suppressed via `NoWarn`. Fix warnings instead
  of extending that list. `NuGetAudit` and `NuGetAuditMode=all` are on, so a vulnerable transitive package
  fails the build too.
- `GeneratePackageOnBuild` is on, so **every** build writes a `.nupkg` and a `.snupkg` into
  `src/ProtobufNetPrimitives/bin/<config>`, a plain `dotnet test` included. Nothing is uploaded by that,
  pushing is `BuildAndPushPackage.bat` and nothing else.
- Versions come from GitVersion.MsBuild out of the git tags, for example `1.0.9-3` for the third commit after
  tag `1.0.8`. Never edit a version property or an assembly version by hand.
- Restore needs nuget.org. If a private feed is configured globally on the machine and answers 404 for public
  packages, restore fails with `NU1301`. Then build with an explicit source:
  `dotnet build src/ProtobufNetPrimitives.sln --source https://api.nuget.org/v3/index.json`.
- Tests are MSTest with the same package set as the sibling repositories: `Microsoft.NET.Test.Sdk`,
  `MSTest.TestAdapter`, `MSTest.TestFramework`, `coverlet.collector` and `GitVersion.MsBuild`. `dotnet test`
  runs 44 tests, they need no network and touch no file. Never claim a test run happened without running it.
- There is no demo project. A behaviour change is verified by the tests, not by starting anything.

## Code conventions

Follow the surrounding code, it is consistent throughout every file:

- **No file header comment blocks.** The sibling repositories start each file with a
  `<copyright file="..." company="Hämmer Electronics">` block, this one never did. Do not add them to single
  files, that would make the repository inconsistent in both directions.
- The file starts with the file scoped namespace, no usings above it.
- XML doc comments on every type and every member, private members included, no exceptions.
- `Nullable`, `ImplicitUsings` and `LangVersion latest` are enabled.
- New `using` directives go into the `GlobalUsings.cs` of the respective project, inside the existing
  `#pragma warning disable IDE0065` block, never at the top of a file. The editorconfig requires usings inside
  the namespace (`csharp_using_directive_placement=inside_namespace:warning`), which global usings cannot
  satisfy, that is what the pragma is for. Do not add other pragmas. The comment text in that block is German
  because Visual Studio generated it, leave it alone.
- Properties are always accessed with `this.` qualification (`dotnet_style_qualification_for_*` at severity
  `warning`).
- `src/.editorconfig` also enforces braces everywhere, no multiple blank lines, four spaces, CRLF, UTF-8, file
  scoped namespaces, `System` usings sorted first and `IDE0005` as warning. Analyzer warnings are fixed, not
  silenced.

## Known quirks

Do not silently "clean up" these, they are existing behaviour:

- **`nint` and `nuint` are stored as `long` and `ulong`.** protobuf-net has no serializer for `IntPtr` and
  `UIntPtr`, a `Data` property of that type throws `InvalidOperationException: No serializer defined for type:
  System.IntPtr` on the first serialization. Up to version 1.0.8.0 both classes had exactly that, so they never
  worked. Since 1.0.9.0 the value travels as `long` respectively `ulong` and the `[ProtoIgnore]` properties
  `Nint` and `Nuint` cast it back, the same trick the date types use. Note that this narrows on a 32 bit
  process, a value that does not fit into `nint` there is truncated.
- **`protobuf-net.BuildTools` does not catch that.** The analyzer is referenced and the build was warning free
  while `DtoNint` was broken. It checks the contract (duplicate field numbers, missing attributes), not whether
  a member type has a serializer. Only a roundtrip finds those, which is why the tests exist.
- **Dates lose information on purpose.** `DtoDateTime` transfers `Ticks` and rebuilds with `new DateTime(long)`,
  so the `DateTimeKind` is always `Unspecified` after the roundtrip. `DtoDateTimeOffset` transfers `UtcTicks`
  and rebuilds with the offset zero, so the point in time survives but the original offset does not. Both are
  pinned by tests.
- **A default `DtoGuid` throws.** In the `NotNullable` namespace `Data` defaults to the empty string and
  `Uuid` is `new Guid(this.Data)`, which throws a `FormatException`. That is what an instance deserialized from
  an empty message looks like. The nullable variant answers `null` instead. Pinned by a test.
- **`Data` is the wire name for everything.** Every class uses `[ProtoMember(1)] Data`, so all messages of this
  library are structurally identical on the wire. Renaming the property or changing the field number breaks
  every deployed client.
- **Two namespaces, identical class names.** `ProtobufNetPrimitives.NotNullable.DtoBool` and
  `ProtobufNetPrimitives.Nullable.DtoBool` cannot be used in the same file without an alias. Additionally the
  namespace `ProtobufNetPrimitives.Nullable` shadows `System.Nullable` inside the library, which is why
  nullable annotations are written as `long?` and never as `Nullable<long>`.
- **`protobuf-net.Grpc` is referenced but not used in code.** The library itself only needs the attributes of
  `protobuf-net`. The reference documents the intended target and pulls the matching version, dropping it would
  change what consumers get.
- **AppVeyor badge without CI in the repository.** `README.md` links an AppVeyor build that is configured
  outside of this repository. There is no `.github` folder and no pipeline file here.
- **`src/ProtobufNetPrimitives.sln.DotSettings`** is tracked and holds nothing but a ReSharper user dictionary.
  Its words (`arcus`, `cosinus`, `Sinh`, `Tanh`) come from a different project, it was copied in. Leave it
  alone.
- **`.gitattributes` sets `* text=auto`**, every rule of the Visual Studio template below it is commented out.
  Any binary file added later needs its own rule.

## Releasing

1. Make the change.
2. Add an entry at the top of `Changelog.md` in the existing format:
   `* **Version 1.0.9.0 (2026-08-15)** : Short description.`
3. Copy the same text into `<PackageReleaseNotes>` in `ProtobufNetPrimitives.csproj`, in the format
   `Version 1.0.9.0 (2026-08-15): Short description.` Both places are maintained by hand and drifted apart
   before.
4. If the target frameworks changed, update the "Available for" list in `README.md`.
5. Commit that.
6. Tag the commit with the plain version number, no `v` prefix (`1.0.9`, `1.0.8`, ...). The existing tags are
   lightweight tags, create new ones the same way. The tag has to exist **before** the package is built,
   otherwise GitVersion burns a prerelease version like `1.0.9-3` into the `.nupkg`.
7. Push the commits and the tag.
8. Run `BuildAndPushPackage.bat` to build and upload. It needs `NUGET_API_KEY` and `GITHUB_API_KEY` in the
   environment and a nuget source named `github`. Uploading to nuget.org cannot be undone, only delisted.

The version in the `Changelog.md` has four parts (`1.0.9.0`), the tag has three (`1.0.9`).

## Git

- **Never amend a commit.** No `git commit --amend`, not for a typo in the message, not to add a forgotten
  file, not even when the commit is still local. Write a follow-up commit instead. The release versions come
  from tags on exact commits, an amended commit leaves its tag pointing at a commit that no longer exists in
  the branch.

## Writing style

- Commit messages are written **in English only**: short, precise subject line, explanatory body when needed.
- Code comments and comments in project files such as `.csproj` are **always English**, regardless of the
  language used in the conversation.
- **No em dashes or en dashes** (`—`, `–`), neither in prose, commit messages, code comments nor documentation.
  Use a regular hyphen, comma, colon, parentheses or a separate sentence.
- German texts (documentation, chat replies) always use real umlauts and ß, never ASCII transliterations such
  as `ae`, `oe`, `ue` or `ss`. Identifiers, file names and configuration keys stay unchanged where umlauts are
  technically undesirable.
