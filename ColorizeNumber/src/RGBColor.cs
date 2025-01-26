using System;
using System.Collections.Generic;
using System.Drawing;

namespace ColorizeNumber
{
    public partial class ColorizeNumber
    {
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
            /// Override of ToString() as "R:{Red}-G:{Green}-B:{Blue}".
            /// </summary>
            /// <returns>String value.</returns>
            public override string ToString()
            {
                return $"R:{Red}-G:{Green}-B:{Blue}";
            }

            #region Comparer & Equality comparer

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

            #endregion Comparer & Equality comparer

            /// <summary>
            /// Compares two RGBColors.
            /// </summary>
            /// <param name="x">First color to compare.</param>
            /// <param name="y">Second color to compare.</param>
            /// <returns>True or false depends on comparasion.</returns>
            public static bool Equals(RGBColor x, RGBColor y)
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

            #region Color similarities

            /// <summary>
            /// Compares two RGBColor and returns similarity by their elements' differences. Lower value indicates higher similarity.
            /// </summary>
            /// <param name="x">First RGBColor.</param>
            /// <param name="y">Second RGBColor.</param>
            /// <returns>Avarage byte values of differences.</returns>
            public static byte GetRGBColorSimilarity(RGBColor x, RGBColor y)
            {
                // Getting avarage differences of red, green and blue values.
                return (byte)(((Math.Abs(x.Red - y.Red) + Math.Abs(x.Green - y.Green) + Math.Abs(x.Blue - y.Blue))) / 3);
            }

            /// <summary>
            /// Compares two RGBColor and return similarity rate by their elements' differences. Higher value indicates highger similarity.
            /// </summary>
            /// <param name="x">First RGBColor.</param>
            /// <param name="y">Second RGBColor.</param>
            /// <returns>Rate of avarege value of differences.  [0.00-100.00]</returns>
            public static double GetRGBColorSimilarityRate(RGBColor x, RGBColor y)
            {
                // Getting avarage differences of red, green and blue values then use it to indicate percentage.
                return ((double)(Math.Abs(x.Red - y.Red) + Math.Abs(x.Green - y.Green) + Math.Abs(x.Blue - y.Blue)) * 100 / 3) / 255;
            }

            /// <summary>
            /// Compares two RGBColor and returns similarity by their elements' 3D differences. Lower value indicates higher similarity.
            /// </summary>
            /// <param name="x">First RGBColor.</param>
            /// <param name="y">Second RGBColor.</param>
            /// <returns>Avarage byte values of differences. [0-255]</returns>
            public static byte GetRGBColorSimilarityBy3D(RGBColor x, RGBColor y)
            {
                // Getting avarage difference of summary of square of red, green and blue values.
                return ((byte)Math.Sqrt(
                    (
                    Math.Pow(Math.Abs(x.Red - y.Red), 2) +
                    Math.Pow(Math.Abs(x.Green - y.Green), 2) +
                    Math.Pow(Math.Abs(x.Blue - y.Blue), 2)) / 3)
                    );
            }

            /// <summary>
            /// Compares two RGBColor and return similarity rate by their elements' 3D differences. Higher value indicates highger similarity.
            /// </summary>
            /// <param name="x">First RGBColor.</param>
            /// <param name="y">Second RGBColor.</param>
            /// <returns>Rate of avarege value of differences. [0.00-100.00]</returns>
            public static double GetRGBColorSimilarityRateBy3D(RGBColor x, RGBColor y)
            {
                // Getting avarage difference of summary of square of red, green and blue values then use it to indicate percentage.
                return
                    Math.Sqrt(
                    (Math.Pow(Math.Abs(x.Red - y.Red), 2) +
                    Math.Pow(Math.Abs(x.Green - y.Green), 2) +
                    Math.Pow(Math.Abs(x.Blue - y.Blue), 2))
                    / 3) * 100 / 255;
            }

            #endregion Color similarities
        }
    }
}