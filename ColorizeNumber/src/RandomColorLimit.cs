using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorizeNumber
{
    public partial class ColorizeNumber
    {
        /// <summary>
        /// Class sets minimum and maximum values of red, green and blue elements of RGBColor.
        /// </summary>
        public class RandomColorLimit
        {
            /// <summary>
            /// Minimum red value. Default 0.
            /// </summary>
            public byte RedMin = byte.MinValue;

            /// <summary>
            /// Maximum red value. Default 0.
            /// </summary>
            public byte RedMax = byte.MaxValue;

            /// <summary>
            /// Minimum green value. Default 0.
            /// </summary>
            public byte GreenMin = byte.MinValue;

            /// <summary>
            /// Maximum green value. Default 0.
            /// </summary>
            public byte GreenMax = byte.MaxValue;

            /// <summary>
            /// Minimum blue value. Default 0.
            /// </summary>
            public byte BlueMin = byte.MinValue;

            /// <summary>
            /// Maximum blue value. Default 0.
            /// </summary>
            public byte BlueMax = byte.MaxValue;

            /// <summary>
            /// Constructor for RandomColorLimit. Minimum values of each come from byte.MinValue which is 0.
            /// </summary>
            /// <param name="redMax">Value for red.</param>
            /// <param name="greenMax">Value for green.</param>
            /// <param name="blueMax">Value for blue.</param>
            public RandomColorLimit(byte redMax, byte greenMax, byte blueMax)
            {
                // Red element minimum and maximum values.
                this.RedMin = byte.MinValue;
                this.RedMax = redMax;

                // Green element minimum and maximum values.
                this.GreenMin = byte.MinValue;
                this.GreenMax = greenMax;

                // Blue element minimum and maximum values.
                this.BlueMin = byte.MinValue;
                this.BlueMax = blueMax;
            }

            /// <summary>
            /// Constructor for RandomColorLimit.
            /// </summary>
            /// <param name="redMin">Minimum value for red.</param>
            /// <param name="redMax">Minimum value for red.</param>
            /// <param name="greenMin">Minimum value for green.</param>
            /// <param name="greenMax">Minimum value for green.</param>
            /// <param name="blueMin">Minimum value for blue.</param>
            /// <param name="blueMax">Minimum value for blue.</param>
            public RandomColorLimit(byte redMin, byte redMax, byte greenMin, byte greenMax, byte blueMin, byte blueMax)
            {
                // Red element minimum and maximum values.
                this.RedMin = redMin;
                this.RedMax = redMax;

                // Green element minimum and maximum values.
                this.GreenMin = greenMin;
                this.GreenMax = greenMax;

                // Blue element minimum and maximum values.
                this.BlueMin = blueMin;
                this.BlueMax = blueMax;
            }
        }
    }
}
