## ColorizeNumber Changelog
[![ColorizeNumber](https://img.shields.io/nuget/v/ColorizeNumber.svg)](https://www.nuget.org/packages/ColorizeNumber/)

<!--
### [Unreleased]

#### Added

#### Changed

#### Removed
-->

#### [1.12.0]
### Added
* `CreateFrameRandomly(int width, int height, List<Tuple<RGBColor, int>> repeatenceData)` method is added. This method creates a frame which provided color repeantence data is used to randomly distributed colors.

#### [1.11.0]
#### Added
* `GetRGBColorSimilarity(RGBColor x, RGBColor y)` method is added. This method compares two `RGBColor` color values and returns similarity by their elements' differences. Lower value indicates higher similarity.
* `GetRGBColorSimilarityRate(RGBColor x, RGBColor y)` method is added.
* `ToString()` override method is added. It returns as "R:{Red}-G:{Green}-B:{Blue}".

### [1.10.0]
#### Added
* `ColorizeFuncByMagenta`, `ColorizeFuncByCyan` and `ColorizeFuncByYellow` colorize functions added to be used for `CreateFrameFromData(string numericText, int width, int height, Func<byte, RGBColor> colorizeFunction)` method.

#### Changed
* `CreateBitmap(Frame frame)` method now check `frame`'s `width` and `height` with length of `colorList` length on frame.

### [1.9.0]
#### Added
* `Equals(RGBColor x, RGBColor y)` method is added to compare two RGBColor.
* `GetColorRepeatance(Frame frame)` and `GetColorRepeatance(Frame frame, ParallelOptions parallelOptions)` methods are added. These two methods return `List<Tuple<RGBColor, int>>` value which is list of tuple items that consists RGBColor and number of its repeatence in given frame.

#### Changed
* Removed and sorting usings.
* Fixing naming inconvention for static variable under RandomColor.cs.
* Removed unnecessary variable on `GetRandomColor()` method under RandomColor.cs.
* Improving on method summaries.

#### Deleted
* `CreateFrameRandomly(RGBColor[] colorList, int width, int height)` was obsolote on v1.8.0. It is removed with this version.

### [1.8.1]
#### Changed
* Partial classes of ColorizeNumber divided into files based on its purpose.

### [1.8.0]
#### Added
* `GetRandomColor()` method is added.
* `GetRandomColor(RandomColorLimit randomColorLimit)` method is added.
* `RandomColorLimit` class is added.
* `RandomColorLimit(byte redMax, byte greenMax, byte blueMax)` constructor is added for `RandomColorLimit`.
* `RandomColorLimit(byte red redMin, byte redMax, byte greenMin, byte greenMax, byte blueMin, byte blueMax)` constructor is added for `RandomColorLimit`.
* `CreateFrameRandomly(int width, int height, RandomColorLimit limits)` method is added.
* `RGBColorComparer` is added which derived from `IComparer<RGBColor>`.
* `ToByteArray(this RGBColor[] rgbColorArray)` extension method is added.
* `ToRGBColorArray(this byte[] byteArray)` extension method is added.

#### Changed
* `CreateFrameRandomly(RGBColor[] colorList, int width, int height)` is obsolote now. Use `CreateFrameRandomly(int width, int height, RGBColor[] colorList)` instead.
* `CreateFrameFromData` method now uses `byte[]` array instead of `int[]` array.

### [1.7.0]
#### Added
* Added support for net461.
* New `RGBColor(Color color)` constructor is added.
* New `CreateFrameRandomly(int width, int height)` method is added.
* New `CreateFrameRandomly(RGBColor[] colorList, int width, int height)` method is added.

### [1.6.0]
#### Added
* New constructor `Frame(int width, int height, RGBColor[] colorList)` is added.
* New default `ColorizeFuncMidTones(byte number)` is added. This method uses tonnes of aqua, yellow and fuchsia based on given specified number.

#### Changed
* New social preview on README.

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
* Summaries now have method and class referrings.
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