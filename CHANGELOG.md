## ColorizeNumber Changelog
[![ColorizeNumber](https://img.shields.io/nuget/v/ColorizeNumber.svg)](https://www.nuget.org/packages/ColorizeNumber/)

<!--
### [Unreleased]

#### Added

#### Changed

#### Removed
-->

### [1.5.0]

#### Changed
* Discussion table's links were fixed for ColorizeNumber.

#### Removed
* `Frame(int width, int height)` constructor was added on v1.3.0 and `Frame(int resolution)` constructor was marked as obsolote. It is now removed.
* `CreateBitmap(Frame frame, int width, int height)` method was marked obsolote on v1.3.0 and `CreateBitmap(Frame frame)` was introduced on same version. Since `Frame` class now has `Width` and `Height`, `CreateBitmap(Frame frame, int width, int height)` method is now removed.

### [1.4.1]

#### Added
* CONTRIBUTING guide is added.
* Discussions guide is added.
* SECURITY guide is added.
* CODE_OF_CONDUCT guide is added.
* New design for CHANGELOG.
* New design for README.

#### Changed
* Summaries now have method and class refere
* New design of README.
* CHANGELOG design fixes.

### [1.4.0]

#### Added
* `ColorizeFuncByRedRate()` colorize function is added.
* `ColorizeFuncByGreenRate()` colorize function is added.
* `ColorizeFuncByBlueRate()` colorize function is added.
* `Color` to `RGBColor` and `RGBColor` to `Color` methods are added as extensions.

#### Changed
* Length checking added into `CreateFrameFromData()`. Checking compare if length of `numericText` with multiple of `width` and `height` are equal.
* `Width` and `Height` values on `Frame` were setting after creating by construct which sets values. Additional value appending is removed.
* Type fixed on code and README.

#### Changed
* `ImageLockMode.ReadWrite` changed to `ImageLockMode.WriteOnly` on `CreateBitmap()` method.

### [1.3.1]

#### Added
* Wiki links added under Example Usage on README.

#### Changed
* `ImageLockMode.ReadWrite` changed to `ImageLockMode.WriteOnly` on `CreateBitmap()` method.
* Suggesting to use `EasySaver.BitmapFile` package under `TestColorizeNumber()` method.
* Hypos are fixed on README.
* CHANGELOG link added under Version History on README.
* CHANGELOG has cleaner view.

### [1.3.0]

#### Added
* `Frame` now has `Width` and `Height` properties.
* `Frame` now has a new constructor. `Frame(int width, int height)`.

#### Changed
* [deprecated] `CreateBitmap(Frame frame, int width, int height)`, use `CreateBitmap(Frame frame)` instead.
* [deprecated] `Frame(int resolution)`, use `Frame(int width, int height)` instead.

### [1.2.0]

#### Added
* Multi-target frameworks (net6.0; net7.0; netstandard2.0) support is added.

#### Removed
* OutputDLL folder is removed.

### [1.1.1]

#### Changed
* Fixed naming vialotions.
* ColorizeNumber splitted into two partial class. Default number-color matching methods are moved to new paritial class.
* ColorizeNumber.dll and ColorizeNumber.xml in OutputDLL folder is updated.

### [1.1.0]

#### Added
* Added `RGBColorEqualityComparer()`.
* Added `GetBitmap()` method.
* Added `ColorizeFuncByRatio()` and `ColorizeFuncByDuality()`.

#### Changed
* Fixed naming vialotions.

### [1.0.0]
Initial version
