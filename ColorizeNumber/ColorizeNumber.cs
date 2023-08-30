﻿using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace ColorizeNumber
{
    /// <summary>
    /// ColorizeNumber, helps to create image data with number-color matching actions.
    /// </summary>
    public class ColorizeNumber
    {
        #region Class definitons

        /// <summary>
        /// Frame holds array of RGBColors.
        /// </summary>
        public class Frame
        {
            /// <summary>
            /// Array of RGBColor
            /// </summary>
            public RGBColor[] ColorList;

            /// <summary>
            /// Constructor with size of array.
            /// </summary>
            /// <param name="resolution">Resolution of the frame. It is size of array which is multiplied width and height.</param>
            public Frame(int resolution)
            {
                // Set an array of RGBColor with specified size.
                ColorList = new RGBColor[resolution];
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
        }

        #endregion Class definitions

        /// <summary>
        /// Returns a frame with changing numeric value from given numericText via provided colorizeFunction.
        /// </summary>
        /// <param name="numericText">String data of numeric values.</param>
        /// <param name="width">Width of frame.</param>
        /// <param name="height">Height of frame.</param>
        /// <param name="colorizeFunction"></param>
        /// <returns>Returns frame.</returns>
        /// <exception cref="ArgumentException">Throws expection if numberText data is null or empty.</exception>
        /// <exception cref="ArgumentNullException">Throws execption if colorizeFunction is not provided.</exception>
        public static Frame CreateFrameFromData(string numericText, int width, int height, Func<byte, RGBColor> colorizeFunction)
        {
            // Checking if numbericText string is null or empty.
            if (string.IsNullOrEmpty(numericText))
            {
                // Throwing an exception.
                throw new ArgumentException($"'{nameof(numericText)}' cannot be null or empty.", nameof(numericText));
            }

            // Checking if colorizeFunction is null. ColorizeFunction is essential to apply for creating color value from numeric data.
            if (colorizeFunction == null)
            {
                // Throwing an exception.
                throw new ArgumentNullException(nameof(colorizeFunction));
            }

            // Creating int array from string with changing char value to int value.
            int[] _dataArray = numericText.Select(p => (int)char.GetNumericValue(p)).ToArray();

            // Creating a frame with given resolution. Resolution is used for specify size of the array on Frame.
            Frame _frame = new Frame(resolution: width * height);

            // Loop for colorizing every value on given data.
            for (int i = 0; i < _dataArray.Length; i++)
            {
                // Assigning value of array with color value by colorize function.
                _frame.ColorList[i] = colorizeFunction((byte)_dataArray[i]);
            }

            // Returning frame.
            return _frame;
        }

        /// <summary>
        /// Default colorize function.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFunc(byte number)
        {
            // Zero value.
            const byte _zero = 0;

            // Switch case for every number on base 10, with default case.
            switch (number)
            {
                case 0: // Black
                    return new RGBColor(red: _zero, green: _zero, blue: _zero);
                case 1: // Dark red
                    return new RGBColor(red: 85, green: _zero, blue: _zero);
                case 2: // Red
                    return new RGBColor(red: 170, green: _zero, blue: _zero);
                case 3: // Light red
                    return new RGBColor(red: 255, green: _zero, blue: _zero);
                case 4: // Dark green
                    return new RGBColor(red: _zero, green: 85, blue: _zero);
                case 5: // Green
                    return new RGBColor(red: _zero, green: 170, blue: _zero);
                case 6: // Light green
                    return new RGBColor(red: _zero, green: 255, blue: _zero);
                case 7: // Dark blue
                    return new RGBColor(red: _zero, green: _zero, blue: 85);
                case 8: // Blue
                    return new RGBColor(red: _zero, green: _zero, blue: 170);
                case 9: // Light blue
                    return new RGBColor(red: _zero, green: _zero, blue: 255);
                default: // White
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
            return new RGBColor(red: (byte)((double)number / 9 * 255), green: (byte)((double)number / 9 * 255), blue: (byte)((double)number / 9 * 255));
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
        /// Return Bitmap with using color data of given frame's array.
        /// </summary>
        /// <param name="frame">Frame whose RGBColor array will be used to create image.</param>
        /// <param name="width">Width of bitmap.</param>
        /// <param name="height">Height of bitmap.</param>
        /// <returns>Returns bitmap.</returns>
        [SupportedOSPlatform("windows")]
        public static Bitmap CreateBitmap(Frame frame, int width, int height)
        {
            // byte array for data. Each pixels hold three components of color.
            byte[] _dataBuffer = new byte[width * height * 3];

            // RGBColor variable for loop.
            RGBColor _rgbColor;

            // Each RGBColor uses three byte length of data. This variable is multiplied index of colorList with three.
            int _multiplier;

            for (int i = 0; i < frame.ColorList.Length; i++)
            {
                // Index for dataBuffer.
                _multiplier = i * 3;

                // RGBColor variable.
                _rgbColor = frame.ColorList[i];

                // ! Order of RGB components is BGR instead of RGB which is alphabetical.

                // Index for blue component of RGBColor.
                _dataBuffer[_multiplier] = _rgbColor.Blue;

                // Index for green component of RGBColor.
                _dataBuffer[_multiplier + 1] = _rgbColor.Green;

                // Index for red component of RGBColor.
                _dataBuffer[_multiplier + 2] = _rgbColor.Red;
            }

            // Creating bitmap with specified width and height.
            Bitmap _bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Creating bitmap data with specified width and height.
            BitmapData _bmpData = _bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, _bitmap.PixelFormat);

            try
            {
                // Copying data from dataBuffer to bmpData with specified lenght.
                Marshal.Copy(_dataBuffer, 0, _bmpData.Scan0, _dataBuffer.Length);
            }
            catch (Exception ex)
            {
                // Throwing exception.
                throw ex;
            }
            //TODO: Free memory?

            // Unlocking bits of bitmap.
            _bitmap.UnlockBits(_bmpData);

            // Returning bitmap.
            return _bitmap;
        }

        /// <summary>
        /// Creates Frame with using colors of Bitmap.
        /// </summary>
        /// <param name="bitmap">Bitmap whose colors will be used to create frame.</param>
        /// <returns>Returns frame.</returns>
        [SupportedOSPlatform("windows")]
        public static Frame GetBitmap(Bitmap bitmap)
        {
            // Creating frame with using given bitmaps width and height.
            Frame _frame = new Frame(resolution: bitmap.Width * bitmap.Height);

            // Creating rectange with using given bitmaps width and height.
            Rectangle _rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            // Creating bitmap data with lock bits.
            BitmapData _data = bitmap.LockBits(_rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);

            // Getting depth of bitmap.
            int _depth = Image.GetPixelFormatSize(_data.PixelFormat) / 8;

            // Creating buffer with resolution.
            byte[] _buffer = new byte[_data.Width * _data.Height * _depth];

            // Copying pixels from bitmap's data scanning into buffer.
            Marshal.Copy(_data.Scan0, _buffer, 0, _buffer.Length);

            // Unlocking bits for bitmap.
            bitmap.UnlockBits(_data);

            // Loop for filling Colorlist of frame via buffer data.
            for (int i = 0; i < bitmap.Width * bitmap.Height; i++)
            {
                // Offset data for each pixels. Depth indicates the length of data used for each pixel.
                int _offset = i * _depth;

                // Filling with creating RGBColor. Data are sorted by blue, green, red alphabetically.
                _frame.ColorList[i] = new RGBColor(red: _buffer[_offset + 2], green: _buffer[_offset + 1], blue: _buffer[_offset + 0]);
            }

            // Returning frame.
            return _frame;
        }
    }
}