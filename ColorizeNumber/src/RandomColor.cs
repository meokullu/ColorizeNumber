using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorizeNumber
{
    public partial class ColorizeNumber
    {
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
    }
}
