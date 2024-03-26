using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ColorizeNumber.ColorizeNumber;

namespace ColorizeNumber
{
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
