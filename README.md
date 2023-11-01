## ColorizeNumber

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
[MIT license](https://github.com/meokullu/ColorizeNumber/blob/master/LICENSE)

### Authors
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)

### Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)