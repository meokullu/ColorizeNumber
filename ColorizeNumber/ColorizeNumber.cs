using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using static ColorizeNumber.ColorizeNumber;

namespace ColorizeNumber
{
    /// <summary>
    /// ColorizeNumber, helps to create image data with number-color matching actions.
    /// </summary>
    public partial class ColorizeNumber
    {
        #region Class definitons

        /// <summary>
        /// Frame holds array of <see cref="RGBColor"/>.
        /// </summary>
        public class Frame
        {
            /// <summary>
            /// Array of RGBColor
            /// </summary>
            public RGBColor[] ColorList;

            /// <summary>
            /// Width of the frame.
            /// </summary>
            public int Width;

            /// <summary>
            /// Height of the frame
            /// </summary>
            public int Height;

            /// <summary>
            /// Constructor with size of array with width and height values.
            /// </summary>
            /// <param name="width">Width of frame.</param>
            /// <param name="height">Height of frame.</param>
            public Frame(int width, int height)
            {
                // Set an array of RGBColor with specified size.
                ColorList = new RGBColor[width * height];

                // Setting width.
                Width = width;

                // Setting height.
                Height = height;
            }

            /// <summary>
            /// Constructor with size of array with width and height values.
            /// </summary>
            /// <param name="width">Width of frame</param>
            /// <param name="height">Height of frame</param>
            /// <param name="colorList"></param>
            public Frame(int width, int height, RGBColor[] colorList)
            {
                // Setting ColorList array with specified colorList values.
                ColorList = colorList;

                // Setting width.
                Width = width;

                // Setting height.
                Height = height;
            }
        }

        /// <summary>
        /// Simple color class. RGBColor holds red, green and blue on byte data type.
        /// </summary>
        public class RGBColor
        {
            /// <summary>
            /// Variable holds pixel's data for red color. [0-255]
            /// </summary>
            public byte Red;

            /// <summary>
            /// Variable holds pixel's data for green color. [0-255]
            /// </summary>
            public byte Green;

            /// <summary>
            /// Variable holds pixel's data for blue color. [0-255]
            /// </summary>
            public byte Blue;

            /// <summary>
            /// Constructor of RGBColor.
            /// </summary>
            /// <param name="red">Red component of RGBColor.</param>
            /// <param name="green">Green component of RGBColor.</param>
            /// <param name="blue">Blue component of RGBColor.</param>
            public RGBColor(byte red, byte green, byte blue)
            {
                // Assigning values.
                this.Red = red;
                this.Green = green;
                this.Blue = blue;
            }

            /// <summary>
            /// Constructor of RGBColor.
            /// </summary>
            /// <param name="color">Color to create RGBColor.</param>
            public RGBColor(Color color)
            {
                // Assigning values.
                this.Red = color.R;
                this.Green = color.G;
                this.Blue = color.B;
            }

            /// <summary>
            /// RGBColor equality comparer derived from IEqualityComparer interface.
            /// </summary>
            public class RGBColorEqualityComparer : IEqualityComparer<RGBColor>
            {
                /// <summary>
                /// Compares two RGBColor based on their red, green and blue color.
                /// </summary>
                /// <param name="x">First color to compare.</param>
                /// <param name="y">Second color to compare.</param>
                /// <returns>Returns true if colors are same, returns false if colors are different or one of the given color is null.</returns>
                bool IEqualityComparer<RGBColor>.Equals(RGBColor x, RGBColor y)
                {
                    // Checking if either of color is null.
                    if (x == null || y == null)
                    {
                        // Returning false to indicate at least one of colors is null.
                        return false;
                    }
                    // Checking if two given color's property values are same.
                    else if (x.Red == y.Red && x.Green == y.Green && x.Blue == y.Blue)
                    {
                        // Returning true to indicate colors are same.
                        return true;
                    }
                    else
                    {
                        // Returning false to indicate colors are different.
                        return false;
                    }
                }

                /// <summary>
                /// Returning hashcode with creating tuple of RGBColor's red, green and blue values.
                /// </summary>
                /// <param name="obj"></param>
                /// <returns>int value of hashcode.</returns>
                int IEqualityComparer<RGBColor>.GetHashCode(RGBColor obj)
                {
                    // Returning hash code.
                    return Tuple.Create(obj.Red, obj.Green, obj.Blue).GetHashCode();
                }
            }

            /// <summary>
            /// RGBColor equality comparer derived from IComparer interface.
            /// </summary>
            public class RGBColorComparer : IComparer<RGBColor>
            {
                /// <summary>
                /// Compares two RGBColor based on hash values.
                /// </summary>
                /// <param name="x">First RGBColor to compare.</param>
                /// <param name="y">Second RGBColor to compare.</param>
                /// <returns>Integer value of comparasion.</returns>
                /// <exception cref="ArgumentNullException"></exception>
                public int Compare(RGBColor x, RGBColor y)
                {
                    return x == null || y == null
                        ? throw new ArgumentNullException()
                        : object.ReferenceEquals(x, y) ? 0 : x.GetHashCode() < y.GetHashCode() ? -1 : x.GetHashCode() > y.GetHashCode() ? +1 : 0;
                }
            }
        }

        /// <summary>
        /// Class sets minimum and maximum values of red, green and blue elements of RGBColor.
        /// </summary>
        public class RandomColorLimit
        {
            /// <summary>
            /// Minimum red value. Default 0.
            /// </summary>
            public byte RedMin = byte.MinValue;

            /// <summary>
            /// Maximum red value. Default 0.
            /// </summary>
            public byte RedMax = byte.MaxValue;

            /// <summary>
            /// Minimum green value. Default 0.
            /// </summary>
            public byte GreenMin = byte.MinValue;

            /// <summary>
            /// Maximum green value. Default 0.
            /// </summary>
            public byte GreenMax = byte.MaxValue;

            /// <summary>
            /// Minimum blue value. Default 0.
            /// </summary>
            public byte BlueMin = byte.MinValue;

            /// <summary>
            /// Maximum blue value. Default 0.
            /// </summary>
            public byte BlueMax = byte.MaxValue;

            /// <summary>
            /// Constructor for RandomColorLimit. Minimum values of each come from byte.MinValue which is 0.
            /// </summary>
            /// <param name="redMax">Value for red.</param>
            /// <param name="greenMax">Value for green.</param>
            /// <param name="blueMax">Value for blue.</param>
            public RandomColorLimit(byte redMax, byte greenMax, byte blueMax)
            {
                // Red element minimum and maximum values.
                this.RedMin = byte.MinValue;
                this.RedMax = redMax;

                // Green element minimum and maximum values.
                this.GreenMin = byte.MinValue;
                this.GreenMax = greenMax;

                // Blue element minimum and maximum values.
                this.BlueMin = byte.MinValue;
                this.BlueMax = blueMax;
            }

            /// <summary>
            /// Constructor for RandomColorLimit.
            /// </summary>
            /// <param name="redMin">Minimum value for red.</param>
            /// <param name="redMax">Minimum value for red.</param>
            /// <param name="greenMin">Minimum value for green.</param>
            /// <param name="greenMax">Minimum value for green.</param>
            /// <param name="blueMin">Minimum value for blue.</param>
            /// <param name="blueMax">Minimum value for blue.</param>
            public RandomColorLimit(byte redMin, byte redMax, byte greenMin, byte greenMax, byte blueMin, byte blueMax)
            {
                // Red element minimum and maximum values.
                this.RedMin = redMin;
                this.RedMax = redMax;

                // Green element minimum and maximum values.
                this.GreenMin = greenMin;
                this.GreenMax = greenMax;

                // Blue element minimum and maximum values.
                this.BlueMin = blueMin;
                this.BlueMax = blueMax;
            }
        }

        #endregion Class definitions

        /// <summary>
        /// Returns a frame with changing numeric value from given numericText via provided colorizeFunction.
        /// </summary>
        /// <param name="numericText">String data of numeric values.</param>
        /// <param name="width">Width of frame.</param>
        /// <param name="height">Height of frame.</param>
        /// <param name="colorizeFunction"></param>
        /// <returns>Returns a frame.</returns>
        /// <exception cref="ArgumentException">Throws expection if numberText data is null or empty.</exception>
        /// <exception cref="ArgumentNullException">Throws execption if colorizeFunction is not provided.</exception>
        public static Frame CreateFrameFromData(string numericText, int width, int height, Func<byte, RGBColor> colorizeFunction)
        {
            // Checking if numericText string is null or empty.
            if (string.IsNullOrEmpty(numericText))
            {
                // Throwing an exception.
                throw new ArgumentException($"'{nameof(numericText)}' cannot be null or empty.", nameof(numericText));
            }

            // Checking if numeric.
            if (numericText.Length != width * height)
            {
                // THrowing an exception.
                throw new ArgumentException($"Provided numericText length is {numericText.Length} while frame resolution was set to {width * height}.");
            }

            // Checking if colorizeFunction is null. ColorizeFunction is essential to apply for creating color value from numeric data.
            if (colorizeFunction == null)
            {
                // Throwing an exception.
                throw new ArgumentNullException(nameof(colorizeFunction));
            }

            // Creating int array from string with changing char value to int value.
            byte[] dataArray = numericText.Select(p => (byte)char.GetNumericValue(p)).ToArray();

            // Creating a frame with given resolution. Resolution is used for specify size of the array on Frame.
            Frame frame = new Frame(width: width, height: height);

            // Loop for colorizing every value on given data.
            for (int i = 0; i < dataArray.Length; i++)
            {
                // Assigning value of array with color value by colorize function.
                frame.ColorList[i] = colorizeFunction(dataArray[i]);
            }

            // Returning frame.
            return frame;
        }

        // Create a random.
        static Random random = new Random();

        /// <summary>
        /// Return random RGBColor.
        /// </summary>
        /// <returns>RGBColor.</returns>
        public static RGBColor GetRandomColor()
        {
            // Creating a RGBColor with random red, green and blue values.
            RGBColor rgbColor = new RGBColor(red: (byte)random.Next(byte.MinValue, byte.MaxValue), green: (byte)random.Next(byte.MinValue, byte.MaxValue), blue: (byte)random.Next(byte.MinValue, byte.MaxValue));

            // Returning created RGBColor.
            return rgbColor;
        }

        /// <summary>
        /// Return random RGBColor based on limits.
        /// </summary>
        /// <returns>RGBColor.</returns>
        public static RGBColor GetRandomColor(RandomColorLimit limits)
        {
            // Creating and returning a RGBColor with random red, green and blue values.
            return new RGBColor(red: (byte)random.Next(limits.RedMin, limits.RedMax), green: (byte)random.Next(limits.GreenMin, limits.GreenMax), blue: (byte)random.Next(limits.BlueMin, limits.BlueMax));
        }

        /// <summary>
        /// Returns a frame with randomly distrubited colors provided by colorlist.
        /// </summary>
        /// <param name="colorList">Array of RGBColor which will be used to create frame with its items.</param>
        /// <param name="width">Width of frame.</param>
        /// <param name="height">Height of frame.</param>
        /// <returns>Returns a frame.</returns>
        [Obsolete("Use CreateFrameRandomly(int width, int height, RGBColor[] colorList)")]
        public static Frame CreateFrameRandomly(RGBColor[] colorList, int width, int height)
        {
            // Checking if provided colorList is null or empty.
            if (colorList == null || colorList.Length == 0)
            {
                // Throwing an exception to indicate colorList is null or empty.
                throw new ArgumentException($"'{nameof(colorList)}' cannot be null or empty.", nameof(colorList));
            }

            // Create a random.
            Random random = new Random();

            // Creating new RGBColor array with specified resolution size.
            RGBColor[] newColorList = new RGBColor[width * height];

            // Loop to distrubite provided colors randomly to each pixels.
            for (int i = 0; i < width * height; i++)
            {
                // Setting color into new array from provided color array randomly.
                newColorList[i] = colorList[random.Next(colorList.Length)];
            }

            // Creating a new frame with specified width, height and colorList.
            Frame frame = new Frame(width: width, height: height, colorList: newColorList);

            // Returning frame.
            return frame;
        }

        /// <summary>
        /// Returns a frame with randomly colors.
        /// </summary>
        /// <param name="width">Width of frame.</param>
        /// <param name="height">Height of frame.</param>
        /// <returns>Returns a frame.</returns>
        public static Frame CreateFrameRandomly(int width, int height)
        {
            // Creating new RGBColor array with specified resolution size.
            RGBColor[] colorList = new RGBColor[width * height];

            // Loop to distrubite provided colors randomly to each pixels.
            for (int i = 0; i < width * height; i++)
            {
                // Setting color randomly.
                colorList[i] = GetRandomColor(limits: new RandomColorLimit(byte.MinValue, byte.MaxValue, byte.MinValue, byte.MaxValue, byte.MinValue, byte.MaxValue));
            }

            // Creating a new frame with specified width, height and colorList.
            Frame frame = new Frame(width: width, height: height, colorList: colorList);

            // Returning frame.
            return frame;
        }

        /// <summary>
        /// Creates and returns a frame which its colors randomly created.
        /// </summary>
        /// <param name="width">Width of frame.</param>
        /// <param name="height">Height of frame.</param>
        /// <param name="limits">Minimum and maximum values for red, green and blue elements of RGBColor.</param>
        /// <returns>Frame</returns>
        public static Frame CreateFrameRandomly(int width, int height, RandomColorLimit limits)
        {
            // Creating new RGBColor array with specified resolution size.
            RGBColor[] colorList = new RGBColor[width * height];

            // Loop to distrubite provided colors randomly to each pixels.
            for (int i = 0; i < width * height; i++)
            {
                // Setting color randomly.
                colorList[i] = GetRandomColor(limits: limits);
            }

            // Creating a new frame with specified width, height and colorList.
            Frame frame = new Frame(width: width, height: height, colorList: colorList);

            // Returning frame.
            return frame;
        }

        /// <summary>
        /// Returns a frame with randomly distrubited colors provided by colorlist.
        /// </summary>
        /// <param name="width">Width of frame.</param>
        /// <param name="height">Height of frame.</param>
        /// <param name="colorList">Array of RGBColor which will be used to create frame with its items.</param>
        /// <returns>Returns a frame.</returns>
        public static Frame CreateFrameRandomly(int width, int height, RGBColor[] colorList)
        {
            // Checking if provided colorList is null or empty.
            if (colorList == null || colorList.Length == 0)
            {
                // Throwing an exception to indicate colorList is null or empty.
                throw new ArgumentException($"'{nameof(colorList)}' cannot be null or empty.", nameof(colorList));
            }

            // Create a random.
            Random random = new Random();

            // Creating new RGBColor array with specified resolution size.
            RGBColor[] newColorList = new RGBColor[width * height];

            // Loop to distrubite provided colors randomly to each pixels.
            for (int i = 0; i < width * height; i++)
            {
                // Setting color into new array from provided color array randomly.
                newColorList[i] = colorList[random.Next(colorList.Length)];
            }

            // Creating a new frame with specified width, height and colorList.
            Frame frame = new Frame(width: width, height: height, colorList: newColorList);

            // Returning frame.
            return frame;
        }
    }

    /// <summary>
    /// This class offers default number-color matching methods.
    /// </summary>
    public partial class ColorizeNumber
    {
        /// <summary>
        /// Default colorize function.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFunc(byte number)
        {
            // Zero value.
            const byte zero = 0;

            // Switch case for every number on base 10, with default case.
            switch (number)
            {
                case 0: // Black
                    return new RGBColor(red: zero, green: zero, blue: zero);
                case 1: // Dark red
                    return new RGBColor(red: 85, green: zero, blue: zero);
                case 2: // Red
                    return new RGBColor(red: 170, green: zero, blue: zero);
                case 3: // Light red
                    return new RGBColor(red: 255, green: zero, blue: zero);
                case 4: // Dark green
                    return new RGBColor(red: zero, green: 85, blue: zero);
                case 5: // Green
                    return new RGBColor(red: zero, green: 170, blue: zero);
                case 6: // Light green
                    return new RGBColor(red: zero, green: 255, blue: zero);
                case 7: // Dark blue
                    return new RGBColor(red: zero, green: zero, blue: 85);
                case 8: // Blue
                    return new RGBColor(red: zero, green: zero, blue: 170);
                case 9: // Light blue
                    return new RGBColor(red: zero, green: zero, blue: 255);
                default: // White
                    return new RGBColor(red: 255, green: 255, blue: 255);
            }
        }

        /// <summary>
        /// Returns mid-tone color based on digit.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncMidTones(byte number)
        {
            // Zero value.
            const byte zero = 0;

            // Switch case for every number on base 10, with default case.
            switch (number)
            {
                case 0: // Black
                    return new RGBColor(red: zero, green: zero, blue: zero);
                case 1: // Aqua
                    return new RGBColor(red: 85, green: 85, blue: zero);
                case 2: // Aqua
                    return new RGBColor(red: 170, green: 170, blue: zero);
                case 3: // Aqua
                    return new RGBColor(red: 255, green: 255, blue: zero);
                case 4: // Yellow
                    return new RGBColor(red: zero, green: 85, blue: 85);
                case 5: // Yellow
                    return new RGBColor(red: zero, green: 170, blue: 170);
                case 6: // Yellow
                    return new RGBColor(red: zero, green: 255, blue: 255);
                case 7: // Fuchsia
                    return new RGBColor(red: 85, green: zero, blue: 85);
                case 8: // Fuchsia
                    return new RGBColor(red: 170, green: zero, blue: 170);
                case 9: // Fuchsia
                    return new RGBColor(red: 255, green: zero, blue: 255);
                default: // Black
                    return new RGBColor(red: 255, green: 255, blue: 255);
            }
        }

        /// <summary>
        /// Returns grayscale color by rate of number between 0 and 9.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByRate(byte number)
        {
            // Creates a RGBColor based on number as percentage of color.
            return new RGBColor(red: (byte)((double)number / 9 * byte.MaxValue), green: (byte)((double)number / 9 * byte.MaxValue), blue: (byte)((double)number / 9 * byte.MaxValue));
        }

        /// <summary>
        /// Returns two different colors based on its duality. 
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByDuality(byte number)
        {
            // Checking if number is even.
            if (number % 2 == 0)
            {
                // Creating and returning black color.
                return new RGBColor(red: 0, green: 0, blue: 0);
            }
            else
            {
                // Creating and returning light green color.
                return new RGBColor(red: 144, green: 238, blue: 144);
            }
        }

        /// <summary>
        /// Return color by rate of red color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByRedRate(byte number)
        {
            // Creates a RGBColor based on number as percentage of color.
            return new RGBColor(red: (byte)((double)number / 9 * byte.MaxValue), green: byte.MinValue, blue: byte.MinValue);
        }

        /// <summary>
        /// Return color by rate of green color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByGreenRate(byte number)
        {
            // Creates a RGBColor based on number as percentage of color.
            return new RGBColor(red: byte.MinValue, green: (byte)((double)number / 9 * byte.MaxValue), blue: byte.MinValue);
        }

        /// <summary>
        /// Return color by rate of blue color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByBlueRate(byte number)
        {
            // Creates a RGBColor based on number as percentage of color.
            return new RGBColor(red: byte.MinValue, green: byte.MinValue, blue: (byte)((double)number / 9 * byte.MaxValue));
        }
    }

    /// <summary>
    /// This class using System.Drawing.
    /// </summary>
    public partial class ColorizeNumber
    {
        /// <summary>
        /// Return Bitmap with using color data of given <see cref="Frame"/>'s array.
        /// </summary>
        /// <param name="frame">Frame whose RGBColor array will be used to create image.</param>
        /// <returns>Returns bitmap.</returns>
        public static Bitmap CreateBitmap(Frame frame)
        {
            // byte array for data. Each pixels hold three components of color.
            byte[] dataBuffer = new byte[frame.Width * frame.Height * 3];

            // RGBColor variable for loop.
            RGBColor rgbColor;

            // Each RGBColor uses three byte length of data. This variable is multiplied index of colorList with three.
            int multiplier;

            for (int i = 0; i < frame.ColorList.Length; i++)
            {
                // Index for dataBuffer.
                multiplier = i * 3;

                // RGBColor variable.
                rgbColor = frame.ColorList[i];

                // ! Order of RGB components is BGR instead of RGB which is alphabetical.

                // Index for blue component of RGBColor.
                dataBuffer[multiplier] = rgbColor.Blue;

                // Index for green component of RGBColor.
                dataBuffer[multiplier + 1] = rgbColor.Green;

                // Index for red component of RGBColor.
                dataBuffer[multiplier + 2] = rgbColor.Red;
            }

            // Creating bitmap with specified width and height.
            Bitmap bitmap = new Bitmap(frame.Width, frame.Height, PixelFormat.Format24bppRgb);

            // Creating bitmap data with specified width and height.
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, frame.Width, frame.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

            try
            {
                // Copying data from dataBuffer to bmpData with specified lenght.
                Marshal.Copy(dataBuffer, 0, bmpData.Scan0, dataBuffer.Length);
            }
            catch (Exception ex)
            {
                // Throwing exception.
                throw ex;
            }
            //TODO: Free memory?

            // Unlocking bits of bitmap.
            bitmap.UnlockBits(bmpData);

            // Returning bitmap.
            return bitmap;
        }

        /// <summary>
        /// Creates Frame with using colors of Bitmap.
        /// </summary>
        /// <param name="bitmap">Bitmap whose colors will be used to create frame.</param>
        /// <returns>Returns frame.</returns>
        public static Frame GetBitmap(Bitmap bitmap)
        {
            // Creating frame with using given bitmaps width and height.
            Frame frame = new Frame(width: bitmap.Width, height: bitmap.Height);

            // Setting width of frame.
            frame.Width = bitmap.Width;

            // Setting height of frame.
            frame.Height = bitmap.Height;

            // Creating rectange with using given bitmaps width and height.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            // Creating bitmap data with lock bits.
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);

            // Getting depth of bitmap.
            int depth = Image.GetPixelFormatSize(data.PixelFormat) / 8;

            // Creating buffer with resolution.
            byte[] buffer = new byte[data.Width * data.Height * depth];

            // Copying pixels from bitmap's data scanning into buffer.
            Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

            // Unlocking bits for bitmap.
            bitmap.UnlockBits(data);

            // Loop for filling Colorlist of frame via buffer data.
            for (int i = 0; i < bitmap.Width * bitmap.Height; i++)
            {
                // Offset data for each pixels. Depth indicates the length of data used for each pixel.
                int offset = i * depth;

                // Filling with creating RGBColor. Data are sorted by blue, green, red alphabetically.
                frame.ColorList[i] = new RGBColor(red: buffer[offset + 2], green: buffer[offset + 1], blue: buffer[offset + 0]);
            }

            // Returning frame.
            return frame;
        }
    }

    /// <summary>
    /// RGBColor to Color and Color to RGBColor extension.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Transforms RGBColor to <see cref="System.Drawing.Color"/>.
        /// </summary>
        /// <param name="rGBColor">RGBColor.</param>
        /// <returns>Color.</returns>
        public static Color ToColor(this ColorizeNumber.RGBColor rGBColor)
        {
            // Creating and returning new Color. Color provided by System.Drawing.
            return Color.FromArgb(red: rGBColor.Red, green: rGBColor.Green, blue: rGBColor.Blue);
        }

        /// <summary>
        /// Transforms <see cref="System.Drawing.Color"/> to RGBColor.
        /// </summary>
        /// <param name="color">Color, provided by System.Drawing.Color.</param>
        /// <returns>RGBColor.</returns>
        public static ColorizeNumber.RGBColor ToRGBColor(this Color color)
        {
            // Creating and returning new RGBColor.
            return new ColorizeNumber.RGBColor(red: color.R, green: color.G, blue: color.B);
        }

        /// <summary>
        /// Transforms array of <see cref="RGBColor"/> to array of <see cref="byte"/>.
        /// </summary>
        /// <param name="rgbColorArray">Array of RGBColor.</param>
        /// <returns>Byte array.</returns>
        public static byte[] ToByteArray(this RGBColor[] rgbColorArray)
        {
            // byte array for data. Each pixels hold three components of color.
            byte[] dataBuffer = new byte[rgbColorArray.Length * 3];

            // RGBColor variable for loop.
            RGBColor rgbColor;

            // Each RGBColor uses three byte length of data. This variable is multiplied index of colorList with three.
            int multiplier;

            //
            for (int i = 0; i < rgbColorArray.Length; i++)
            {
                // Index for dataBuffer.
                multiplier = i * 3;

                // RGBColor variable.
                rgbColor = rgbColorArray[i];

                // ! Order of RGB components is BGR instead of RGB which is alphabetical.

                // Index for blue component of RGBColor.
                dataBuffer[multiplier] = rgbColor.Blue;

                // Index for green component of RGBColor.
                dataBuffer[multiplier + 1] = rgbColor.Green;

                // Index for red component of RGBColor.
                dataBuffer[multiplier + 2] = rgbColor.Red;
            }

            // Returning of result array.
            return dataBuffer;
        }

        /// <summary>
        /// Transforms array of <see cref="byte"/> to array of <see cref="RGBColor"/>.
        /// </summary>
        /// <param name="byteArray">Array of byte.</param>
        /// <returns>RGBColor array.</returns>
        public static RGBColor[] ToRGBColorArray(this byte[] byteArray)
        {
            // RGBColor variable for loop.
            RGBColor[] rgbColorArray = new RGBColor[byteArray.Length / 3];

            // Loop for array
            for (int i = 0; i < byteArray.Length; i = i + 3)
            {
                // ! Order of RGB components is BGR instead of RGB which is alphabetical.

                // Setting index of array with creating RGBColor.
                rgbColorArray[i / 3] = new RGBColor(red: byteArray[i + 2], green: byteArray[i + 1], blue: byteArray[i]);
            }

            // Returning of result array.
            return rgbColorArray;
        }
    }
}