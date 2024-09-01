using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ColorizeNumber.ColorizeNumber.RGBColor;

namespace ColorizeNumber
{
    public partial class ColorizeNumber
    {
        /// <summary>
        /// Returns a list of a tuple list which consist <see cref="RGBColor"/> and number of repeatence.
        /// </summary>
        /// <param name="frame">Frame.</param>
        /// <returns>List of tuple which consists color and int.</returns>
        public static List<Tuple<RGBColor, int>> GetColorRepeatance(Frame frame)
        {
            // Creating a list of tuple which consists RGBColor and int with capasity of frame's ColorList length.
            List<Tuple<RGBColor, int>> repeatenceList = new List<Tuple<RGBColor, int>>(frame.ColorList.Length);

            // Loop to check every color for repeatence.
            for (int i = 0; i < frame.ColorList.Length; i++)
            {
                // Creating an item to check if it is already exists in the repeatence list.
                Tuple<RGBColor, int> repeatenceItem = repeatenceList.Where(p => RGBColor.Equals(p.Item1, frame.ColorList[i])).SingleOrDefault();

                // Checking if it exists in the list.
                if (repeatenceItem != null)
                {
                    // Increasing repeatence value of the color.
                    repeatenceList[repeatenceList.IndexOf(repeatenceItem)] = new Tuple<RGBColor, int>(repeatenceItem.Item1, repeatenceItem.Item2 + 1);
                }
                else
                {
                    // Creating a tuple item and add it into the list.
                    repeatenceList.Add(new Tuple<RGBColor, int>(frame.ColorList[i], 1));
                }
            };

            // Returning repeatence list.
            return repeatenceList;
        }

        /// <summary>
        /// Returns a list of a tuple list which consist <see cref="RGBColor"/> and number of repeatence with parallelism.
        /// </summary>
        /// <param name="frame">Frame.</param>
        /// <param name="parallelOptions">Parallel options.</param>
        /// <returns>List of tuple which consists color and int.</returns>
        public static List<Tuple<RGBColor, int>> GetColorRepeatance(Frame frame, ParallelOptions parallelOptions)
        {
            // Creating a variable to use for comparasion.
            RGBColorEqualityComparer comp = new RGBColorEqualityComparer();

            // Creating a dictionary which consists RGBColor and integer value for repeatence.
            ConcurrentDictionary<RGBColor, int> repeatenceDictionary = new ConcurrentDictionary<RGBColor, int>(comparer: comp);

            // Loop for paralel.
            _ = Parallel.ForEach(frame.ColorList, parallelOptions, (color) =>
            {
                // Adding if repeatence doesn't exist or increasing number of repeatence if repeatence does exist.
                _ = repeatenceDictionary.AddOrUpdate(color, 1, (key, value) => value + 1);
            });

            // Creating a list of tuple which consists RGBColor and int with capasity of frame's ColorList length.
            List<Tuple<RGBColor, int>> repeatenceList = new List<Tuple<RGBColor, int>>(frame.ColorList.Length);

            // Setting repeatenceList with value by dictionary.
            repeatenceList = repeatenceDictionary
                .Select(p => new Tuple<RGBColor, int>(new RGBColor(red: p.Key.Red, green: p.Key.Green, blue: p.Key.Blue), p.Value))
                .ToList();

            // Returning repeatence list.
            return repeatenceList;
        }
    }
}