# Change Log
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [Unreleased]

## [2.3.0] - 2018-03-27
- Add `Set.Empty()` static method.

## [2.2.0] - 2018-03-27
- Add `Enumerables.ToDictionary` extension methods.
- Add `Enumerables.CreateSafetyCopy` extension method.

## [2.1.0] - 2018-03-23
- Add `CodePoint.IsSurrogatePair` property.
- Add API documentation.

## [2.0.0] - 2018-03-22
- **Breaking** library now targets .NET Standard 2.0.
- **Breaking** remove `Arrays.Empty()`.  Use `Array.Empty()` from the standard library instead.
- **Breaking** change name of `IReadOnlySet.TryGet()` to `TryGetValue()`.
- **Breaking** `IReadOnlySet.TryGetValue()` (was `TryGet()`) now returns input value when value is not found.
- Add `CodePoint` struct that represents a Unicode code point.
- Add `CodePointSet`: a set of Unicode code points.

## [1.28.0] - 2018-03-12
- Add `BinaryMath.CountBitsSet` to count the number of bits set to 1.

## [1.27.0] - 2018-03-01
- Add `IBuffer` interface and `DataBuffer` class, which represents a buffer of bytes.
- Add `Enumerables.Of` method, which returns an enumerable singleton.

## [1.26.0] - 2017-06-02
- **Breaking** change name of `Enumerables.AsSmartList()` to `AsList()`.
- **Breaking** change signature of `Enumerables.AsSmartList()` to return `IReadOnlyList<T>`.
- **Breaking** change `SmartList<T>` is now an internal class.
- `AsSmartList()` no longer wraps the enumerable if it's already a list.
- Fix bug in SmartList when wrapping an empty non-enumerable and iterating over it.

## [1.25.1] - 2017-06-02
- Generate and include debugging symbols.

## [1.25.0] - 2017-05-30
- Add `Enumerables.ZipEqual()`, an alternative to LINQ's `Zip()`
  that ensures both sequences have the same length.

## [1.24.0] - 2017-05-29
- Add `SmartList<T>` class, which wraps an enumerable to provide a list interface,
  while minimizing enumerating the enumerable and ensuring it is enumerated only once.
- Add `Enumerables.AsSmartList()`, which is a more conventient way to wrap an enumerable
  in a `SmartList<T>`.
- Fix `Enumerables.TryGetCount()` such that Resharper no longer complains
  about enumerating an enumerable.

## [1.23.0] - 2017-05-23
- Add `SetComparer` for comparing sets.

## [1.22.0] - 2017-03-14
- Add `ListSlice` and some enumerable extensions.

## [1.21.0] - 2017-03-14
- Switch to new `.csproj` format.

## [1.20.0] - 2017-03-02
- Implementations of `IEqualityComparer` no longer throw an exception when `GetHashCode()` is given `null`.

## [1.19.0] - 2017-02-21
- Add `Chars.IsHexDigit()` function.
- First release with Changelog.