## ColorizeNumber
[![ColorizeNumber](https://img.shields.io/nuget/v/ColorizeNumber.svg)](https://www.nuget.org/packages/ColorizeNumber/) [![ColorizeNumber](https://img.shields.io/nuget/dt/ColorizeNumber.svg)](https://www.nuget.org/packages/ColorizeNumber/) [![License](https://img.shields.io/github/license/meokullu/ColorizeNumber.svg)](https://github.com/meokullu/ColorizeNumber/blob/master/LICENSE)

ColorizeNumber - Bodrum Papatya is a project to visualize numeric data.

[Download on NuGet gallery](https://www.nuget.org/packages/ColorizeNumber/)

### Description

ColorizeNumber - Bodrum Papatya helps you to visualize numeric data.

### Example Usage

```
private void TestColorizeNumber()
{
  // Data - 25 charachters
  string dataText = "1122334455667788990012345";

  // Data to Frame (25 byte length)
  Frame frame = CreateFrameFromData(dataText, 5, 5, colorizeFunction: ColorizeFunc);

  // Frame to Bitmap (5x5)
  Bitmap bitmap = CreateBitmap(frame);

  // Saving bitmap.
  bitmap.Save("./ColorizeNumberTest.bmp", ImageFormat.Bmp);

  // Alternative saving, alpha version. It automatically saves bitmap with named as datetime in folder named "Data" https://www.nuget.org/packages/EasySaver.BitmapFile/
  // Save(Bitmap bitmap)
  // SaveToFolder(Bitmap bitmap)
}
```

### Build your own colorize function.
```
private static RGBColor MyColorizeFunc(byte number)
{
  if (number < 5) // If number is 0, 1, 2, 3, 4 returns white color.
  {
    return new RGBColor(red: 255, green: 255, blue: 255);
  }
  else // If number is 5, 6, 7, 8, 9 returns black color.
  {
    return new RGBColor(red: 0, green: 0, blue: 0);
  }
}
```

To check listed methods, example of output visit wiki page. [ColorizeNumber Wiki](https://github.com/meokullu/ColorizeNumber/wiki/Home)

### Version History
See [Changelog](https://github.com/meokullu/ColorizeNumber/blob/master/CHANGELOG.md)

### Task list
* Create an issue or check task list: [Issues](https://github.com/meokullu/ColorizeNumber/issues)

### Licence
This repository is licensed under the "MIT" license. See [MIT license](https://github.com/meokullu/ColorizeNumber/blob/master/LICENSE).

### Authors & Contributing

If you'd like to contribute, then contribute. [contributing guide](https://github.com/meokullu/ColorizeNumber/blob/master/CONTRIBUTING.md).

[![Contributors](https://contrib.rocks/image?repo=meokullu/ColorizeNumber)](https://github.com/meokullu/ColorizeNumber/graphs/contributors)

### Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)
