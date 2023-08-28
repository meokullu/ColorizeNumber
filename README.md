# ColorizeNumber

ColorizeNumber - Bodrum Papatya is a project to visualize numeric data.

![ColorizeNumber](https://github.com/meokullu/ColorizeNumber/blob/master/ColorizeNumber/Resources/preview.png)

## Description

ColorizeNumber - Bodrum Papatya helps you to visualize numeric data.

## Built-in Classes

### Frame
```
public Frame(int resolution)
{
    colorList = new RGBColor[resolution];
}
```

### RGBColor
```
 public RGBColor(byte red, byte green, byte blue)
 {
     this.red = red;
     this.green = green;
     this.blue = blue;
 }
```

## Listed Methods
```
CreateFrameFromData(string numericText, int width, int height, Func<byte, RGBColor> colorizeFunction)
```
Returns Frame which consists array list of RGBColor.

* string numericText: Numerical string text. E.g "1071"

* int width: Width of frame. This value creates resoultion with height.

* int height: Height of frame. This value creates resoultion with width.

* Func<byte, RGBColor> colorizeFunction: A functions which will be used to choose colors for specified number.


```
ColorizeFunc(byte number)
```
Returns RGBColor.

* byte number: Number value which will be converted to RGBColor via function.


```
CreateBitmap(Frame frame, int width, int height)
```
Returns Bitmap which is filled with given colorList from frame.

* Frame frame: A frame which consists array list of RGBColor.

* int width: Width of bitmap.

* int height: Height of bitmap.

## Example Usage

### Testing ColorizeNumber
```
private void TestColorizeNumber()
{
  // Data - 25 charachters
  string dataText = "1122334455667788990012345"

  // Data to Frame (25 byte length)
  Frame frame = CreateFrameFromData(dateText, 5, 5, colorizeFunction: ColorizeFunc);

  // Frame to Bitmap (5x5)
  Bitmap bitmap = CreateBitmap(frame, 5, 5);

  // Saving bitmap.
  bitmap.Save("./ColorizeNumberTest.bmp", ImageFormat.Bmp);
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
  else // If number is 5,6,7,8,9 returns black color.
  {
    return new RGBColor(red: 0, green: 0, blue: 0);
  }
}
```

## Version History

* 1.0.0 Initial Release

## Licence
No licence is required.

## Authors
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)

## Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)

