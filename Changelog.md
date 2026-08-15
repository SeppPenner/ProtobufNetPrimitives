Change history
--------------

* **Version 1.1.0.0 (2026-08-15)** : Removed support for Net9.0 as it is out of support, added support for Net10.0, updated NuGet packages, added unit tests, fixed DtoNint and DtoNuint (protobuf-net has no serializer for nint and nuint, the values now travel as long and ulong, use the new properties Nint and Nuint), fixed the nullable DateTimeOffset property of the non nullable DtoDateTimeOffset. The two fixes change the public API, which is why the minor version is raised.
* **Version 1.0.7.0 (2024-05-16)** : Removed support for Net7.0.
* **Version 1.0.6.0 (2023-12-07)** : Updated NuGet packages, added support for Net8.0.
* **Version 1.0.5.0 (2023-11-13)** : Updated NuGet packages, removed support for netstandard.
* **Version 1.0.4.0 (2023-11-11)** : Updated NuGet packages.
* **Version 1.0.3.0 (2023-04-07)** : Removed NetCore3.1, Updated NuGet packages.
* **Version 1.0.2.0 (2022-11-10)** : Updated NuGet packages, added support for Net7.0, removed support for Net5.0.
* **Version 1.0.1.0 (2022-10-30)** : Updated nuget packages.
* **Version 1.0.0.0 (2022-02-21)** : 1.0 release.