using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqRetValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** GetStringSubset() *****");

            IEnumerable<string> redColors1 = GetStringSubset();

            foreach (string item in redColors1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n***** GetStringSubsetAsArray() *****");

            Array redColors2 = GetStringSubsetAsArray();

            foreach (string item in redColors2)
            {
                Console.WriteLine(item);
            }
        }

        static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Red", "Light Red", "Green", "Yellow", "Dark Red", "Purple" };

            IEnumerable<string> theRedColors = from c in colors
                                               where c.Contains("Red")
                                               select c;

            return theRedColors;
        }

        static Array GetStringSubsetAsArray()
        {
            string[] colors = { "Red", "Light Red", "Green", "Yellow", "Dark Red", "Purple" };

            var theRedColors = (from c in colors
                               where c.Contains("Red")
                               select c).ToArray();

            return theRedColors;
        }
    }
}
