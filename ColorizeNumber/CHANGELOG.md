## ColorizeNumber Changelog

<!--
## [Unreleased]

### Added

### Changed

### Removed
-->

## [1.x.y] (Upcoming)
*

## [1.3.0]

### Added
* `Frame` now has `Width` and `Height` properties.
* `Frame` now has a new constructor. `Frame(int width, int height)`.

### Changed
* [deprecated] `CreateBitmap(Frame frame, int width, int height)`, use `CreateBitmap(Frame frame)` instead.
* [deprecated] `Frame(int resolution)`, use `Frame(int width, int height)` instead.

## [1.2.0]

### Added
* Multi-target frameworks (net6.0; net7.0; netstandard2.0) support is added.

### Removed
* OutputDLL folder is removed.

## [1.1.1]

### Changed
* Fixed naming vialotions.
* ColorizeNumber splitted into two partial class. Default number-color matching methods are moved to new paritial class.
* ColorizeNumber.dll and ColorizeNumber.xml in OutputDLL folder is updated.

## [1.1.0]

### Added
* Added `RGBColorEqualityComparer()`.
* Added `GetBitmap()` method.
* Added `ColorizeFuncByRatio()` and `ColorizeFuncByDuality()`.

### Changed
* Fixed naming vialotions.

## [1.0.0]
Initial version
