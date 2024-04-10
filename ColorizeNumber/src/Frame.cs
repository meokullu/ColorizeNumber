using System;
using System.Linq;

namespace ColorizeNumber
{
    public partial class ColorizeNumber
    {
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
}