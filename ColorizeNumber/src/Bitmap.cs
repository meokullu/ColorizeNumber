using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ColorizeNumber
{
    /// <summary>
    /// This class using System.Drawing.
    /// </summary>
    public partial class ColorizeNumber
    {
        /// <summary>
        /// Return Bitmap with using color data of given <see cref="Frame"/>'s array.
        /// </summary>
        /// <param name="frame">Frame whose RGBColor array will be used to create image.</param>
        /// <returns>Returns bitmap.</returns>
        public static Bitmap CreateBitmap(Frame frame)
        {
            // byte array for data. Each pixels hold three components of color.
            byte[] dataBuffer = new byte[frame.Width * frame.Height * 3];

            // RGBColor variable for loop.
            RGBColor rgbColor;

            // Each RGBColor uses three byte length of data. This variable is multiplied index of colorList with three.
            int multiplier;

            for (int i = 0; i < frame.ColorList.Length; i++)
            {
                // Index for dataBuffer.
                multiplier = i * 3;

                // RGBColor variable.
                rgbColor = frame.ColorList[i];

                // ! Order of RGB components is BGR instead of RGB which is alphabetical.

                // Index for blue component of RGBColor.
                dataBuffer[multiplier] = rgbColor.Blue;

                // Index for green component of RGBColor.
                dataBuffer[multiplier + 1] = rgbColor.Green;

                // Index for red component of RGBColor.
                dataBuffer[multiplier + 2] = rgbColor.Red;
            }

            // Creating bitmap with specified width and height.
            Bitmap bitmap = new Bitmap(frame.Width, frame.Height, PixelFormat.Format24bppRgb);

            // Creating bitmap data with specified width and height.
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, frame.Width, frame.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

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

        /// <summary>
        /// Creates Frame with using colors of Bitmap.
        /// </summary>
        /// <param name="bitmap">Bitmap whose colors will be used to create frame.</param>
        /// <returns>Returns frame.</returns>
        public static Frame GetBitmap(Bitmap bitmap)
        {
            // Creating frame with using given bitmaps width and height.
            Frame frame = new Frame(width: bitmap.Width, height: bitmap.Height);

            // Setting width of frame.
            frame.Width = bitmap.Width;

            // Setting height of frame.
            frame.Height = bitmap.Height;

            // Creating rectange with using given bitmaps width and height.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            // Creating bitmap data with lock bits.
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);

            // Getting depth of bitmap.
            int depth = Image.GetPixelFormatSize(data.PixelFormat) / 8;

            // Creating buffer with resolution.
            byte[] buffer = new byte[data.Width * data.Height * depth];

            // Copying pixels from bitmap's data scanning into buffer.
            Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

            // Unlocking bits for bitmap.
            bitmap.UnlockBits(data);

            // Loop for filling Colorlist of frame via buffer data.
            for (int i = 0; i < bitmap.Width * bitmap.Height; i++)
            {
                // Offset data for each pixels. Depth indicates the length of data used for each pixel.
                int offset = i * depth;

                // Filling with creating RGBColor. Data are sorted by blue, green, red alphabetically.
                frame.ColorList[i] = new RGBColor(red: buffer[offset + 2], green: buffer[offset + 1], blue: buffer[offset + 0]);
            }

            // Returning frame.
            return frame;
        }
    }
}
