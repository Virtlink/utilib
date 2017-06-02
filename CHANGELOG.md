# Change Log
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [Unreleased]

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