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
        static Random s_random = new Random();

        /// <summary>
        /// Return random RGBColor.
        /// </summary>
        /// <returns>RGBColor.</returns>
        public static RGBColor GetRandomColor()
        {
            // Creating and returning a RGBColor with random red, green and blue values.
            return new RGBColor(red: (byte)s_random.Next(byte.MinValue, byte.MaxValue), green: (byte)s_random.Next(byte.MinValue, byte.MaxValue), blue: (byte)s_random.Next(byte.MinValue, byte.MaxValue)); ;
        }

        /// <summary>
        /// Return random RGBColor based on <see cref="RandomColorLimit"/> limits.
        /// </summary>
        /// <returns>RGBColor.</returns>
        public static RGBColor GetRandomColor(RandomColorLimit limits)
        {
            // Creating and returning a RGBColor with random red, green and blue values.
            return new RGBColor(red: (byte)s_random.Next(limits.RedMin, limits.RedMax), green: (byte)s_random.Next(limits.GreenMin, limits.GreenMax), blue: (byte)s_random.Next(limits.BlueMin, limits.BlueMax));
        }
    }
}