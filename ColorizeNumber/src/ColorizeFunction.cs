namespace ColorizeNumber
{
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

        /// <summary>
        /// Return color by rate of magenta (red-blue) color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByMagentaRate(byte number)
        {
            // Creates a RGBColor based on number as percentage of color.
            return new RGBColor(red: (byte)((double)number / 9 * byte.MaxValue), green: byte.MinValue, blue: (byte)((double)number / 9 * byte.MaxValue));
        }

        /// <summary>
        /// Return color by rate of yellow (red-green) color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByYellowRate(byte number)
        {
            // Creates a RGBColor based on number as percentage of color.
            return new RGBColor(red: (byte)((double)number / 9 * byte.MaxValue), green: (byte)((double)number / 9 * byte.MaxValue), byte.MinValue);
        }

        /// <summary>
        /// Return color by rate of cyan (green-blue) color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByCyanRate(byte number)
        {
            return new RGBColor(red: byte.MinValue, green: (byte)((double)number / 9 * byte.MaxValue), blue: (byte)((double)number / 9 * byte.MaxValue));
        }
    }
}