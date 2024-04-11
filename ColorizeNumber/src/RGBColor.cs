using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}