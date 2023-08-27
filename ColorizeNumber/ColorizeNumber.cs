using System.Drawing;
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
            public RGBColor[] colorList;

            /// <summary>
            /// Constructor with size of array.
            /// </summary>
            /// <param name="resolution">Resolution of the frame. It is size of array which is multiplied width and height.</param>
            public Frame(int resolution)
            {
                // Set an array of RGBColor with specified size.
                colorList = new RGBColor[resolution];
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
            public byte red;

            /// <summary>
            /// Variable holds pixel's data for green color. [0-255]
            /// </summary>
            public byte green;

            /// <summary>
            /// Variable holds pixel's data for blue color. [0-255]
            /// </summary>
            public byte blue;

            /// <summary>
            /// Constructor of RGBColor.
            /// </summary>
            /// <param name="red">Red component of RGBColor.</param>
            /// <param name="green">Green component of RGBColor.</param>
            /// <param name="blue">Blue component of RGBColor.</param>
            public RGBColor(byte red, byte green, byte blue)
            {
                // Assigning values.
                this.red = red;
                this.green = green;
                this.blue = blue;
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
                _frame.colorList[i] = colorizeFunction((byte)_dataArray[i]);
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
        /// Return Bitmap with using color data of given frame's array.
        /// </summary>
        /// <param name="frame">Frame whose RGBColor array will be used to create image.</param>
        /// <param name="width">Width of bitmap.</param>
        /// <param name="height">Height of bitmap.</param>
        /// <returns></returns>
        [SupportedOSPlatform("windows")]        
        public static Bitmap CreateBitmap(Frame frame, int width, int height)
        {
            // byte array for data. Each pixels hold three components of color.
            byte[] dataBuffer = new byte[width * height * 3];

            // RGBColor variable for loop.
            RGBColor _rgbColor;

            // Each RGBColor uses three byte length of data. This variable is multiplied index of colorList with three.
            int _multiplier;

            for (int i = 0; i < frame.colorList.Length; i++)
            {
                // Index for dataBuffer.
                _multiplier = i * 3;

                // RGBColor variable.
                _rgbColor = frame.colorList[i];

                // ! Order of RGB components is BGR instead of RGB which is alphabetical.
                
                // Index for blue component of RGBColor.
                dataBuffer[_multiplier] = _rgbColor.blue;

                // Index for green component of RGBColor.
                dataBuffer[_multiplier + 1] = _rgbColor.green;

                // Index for red component of RGBColor.
                dataBuffer[_multiplier + 2] = _rgbColor.red;
            }

            // Creating bitmap with specified width and height.
            Bitmap bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Creating bitmap data with specified width and height.
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bitmap.PixelFormat);

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
    }
}