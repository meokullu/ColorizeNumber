namespace ColorizeNumber
{
    /// <summary>
    /// This class offers default number-color matching methods.
    /// </summary>
    public partial class ColorizeNumber
    {
        private const byte _zero = 0;
        private const byte _oneThird = 85;
        private const byte _twoThird = 170;
        private const byte _byteMax = 255;
        private const double _ratioToTen = (double)_byteMax / 9;

        private static readonly RGBColor s_black = new RGBColor(_zero, _zero, _zero);

        #region Red

        private static readonly RGBColor s_darkRed = new RGBColor(_oneThird, _zero, _zero);
        private static readonly RGBColor s_mediumRed = new RGBColor(_twoThird, _zero, _zero);
        private static readonly RGBColor s_lightRed = new RGBColor(_byteMax, _zero, _zero);

        #endregion Red

        #region Green

        private static readonly RGBColor s_darkGreen = new RGBColor(_zero, _oneThird, _zero);
        private static readonly RGBColor s_mediumGreen = new RGBColor(_zero, _twoThird, _zero);
        private static readonly RGBColor s_lightGreen = new RGBColor(_zero, _byteMax, _zero);

        #endregion Green

        #region Blue

        private static readonly RGBColor s_darkBlue = new RGBColor(_zero, _zero, _oneThird);
        private static readonly RGBColor s_mediumBlue = new RGBColor(_zero, _zero, _twoThird);
        private static readonly RGBColor s_lightBlue = new RGBColor(_zero, _zero, _byteMax);

        #endregion Blue

        #region Aqua

        private static readonly RGBColor s_darkAqua = new RGBColor(_oneThird, _oneThird, _zero);
        private static readonly RGBColor s_mediumAqua = new RGBColor(_twoThird, _twoThird, _zero);
        private static readonly RGBColor s_lightAqua = new RGBColor(_byteMax, _byteMax, _zero);

        #endregion Aqua

        #region Yellow

        private static readonly RGBColor s_darkYellow = new RGBColor(_zero, _oneThird, _oneThird);
        private static readonly RGBColor s_mediumYellow = new RGBColor(_zero, _twoThird, _twoThird);
        private static readonly RGBColor s_lightYellow = new RGBColor(_zero, _byteMax, _byteMax);

        #endregion Yellow

        #region Fuchsia

        private static readonly RGBColor s_darkFuchsia = new RGBColor(_oneThird, _zero, _oneThird);
        private static readonly RGBColor s_mediumFuchsia = new RGBColor(_twoThird, _zero, _twoThird);
        private static readonly RGBColor s_lightFuchsia = new RGBColor(_byteMax, _zero, _byteMax);

        #endregion Fuchsia

        private static readonly RGBColor s_white = new RGBColor(_byteMax, _byteMax, _byteMax);

        private static readonly RGBColor s_specialGreen = new RGBColor(red: 144, green: 238, blue: 144);

        /// <summary>
        /// Default colorize function.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFunc(byte number)
        {
            // Switch case for every number on base 10, with default case.
            switch (number)
            {
                case 0: // Black
                    return s_black;
                case 1: // Dark red
                    return s_darkRed;
                case 2: // Red
                    return s_mediumRed;
                case 3: // Light red
                    return s_lightRed;
                case 4: // Dark green
                    return s_darkGreen;
                case 5: // Green
                    return s_mediumGreen;
                case 6: // Light green
                    return s_lightGreen;
                case 7: // Dark blue
                    return s_darkBlue;
                case 8: // Blue
                    return s_mediumBlue;
                case 9: // Light blue
                    return s_lightBlue;
                default: // White
                    return s_white;
            }
        }

        /// <summary>
        /// Returns mid-tone color based on digit.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncMidTones(byte number)
        {
            // Switch case for every number on base 10, with default case.
            switch (number)
            {
                case 0: // Black
                    return s_black;
                case 1: // Aqua
                    return s_darkAqua;
                case 2: // Aqua
                    return s_mediumAqua;
                case 3: // Aqua
                    return s_lightAqua;
                case 4: // Yellow
                    return s_darkYellow;
                case 5: // Yellow
                    return s_mediumYellow;
                case 6: // Yellow
                    return s_lightYellow;
                case 7: // Fuchsia
                    return s_darkFuchsia;
                case 8: // Fuchsia
                    return s_mediumFuchsia;
                case 9: // Fuchsia
                    return s_lightFuchsia;
                default: // Black
                    return s_black;
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
            return new RGBColor(red: (byte)(number * _ratioToTen), green: (byte)(number * _ratioToTen), blue: (byte)(number * _ratioToTen));
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
                return s_black;
            }
            else
            {
                // Creating and returning light green color.
                return s_specialGreen;
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
            return new RGBColor(red: (byte)(number * _ratioToTen), green: _zero, blue: _zero);
        }

        /// <summary>
        /// Return color by rate of green color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByGreenRate(byte number)
        {
            // Creates a RGBColor based on number as percentage of color.
            return new RGBColor(red: _zero, green: (byte)(number * _ratioToTen), blue: _zero);
        }

        /// <summary>
        /// Return color by rate of blue color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByBlueRate(byte number)
        {
            // Creates a RGBColor based on number as percentage of color.
            return new RGBColor(red: _zero, green: _zero, blue: (byte)(number * _ratioToTen));
        }

        /// <summary>
        /// Return color by rate of magenta (red-blue) color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByMagentaRate(byte number)
        {
            // Creates a RGBColor based on number as percentage of color.
            return new RGBColor(red: (byte)(number * _ratioToTen), green: _zero, blue: (byte)(number * _ratioToTen));
        }

        /// <summary>
        /// Return color by rate of yellow (red-green) color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByYellowRate(byte number)
        {
            // Creates a RGBColor based on number as percentage of color.
            return new RGBColor(red: (byte)(number * _ratioToTen), green: (byte)(number * _ratioToTen), _zero);
        }

        /// <summary>
        /// Return color by rate of cyan (green-blue) color.
        /// </summary>
        /// <param name="number">A number whose value will be converted to color value.</param>
        /// <returns>Returns RGBColor.</returns>
        public static RGBColor ColorizeFuncByCyanRate(byte number)
        {
            return new RGBColor(red: _zero, green: (byte)(number * _ratioToTen), blue: (byte)(number * _ratioToTen));
        }
    }
}