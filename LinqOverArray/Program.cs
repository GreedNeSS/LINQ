using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryOverStrings();
            QueryOverStringsWithExtensionMethods();
            QueryOverStringsLongHand();
            QueryOverInts();
            ImmediateExecution();
        }

        public static void QueryOverStrings()
        {
            string[] currentVideoGames =
            {
                "Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"
            };

            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            ReflectOverQueryResults(subset);

            foreach (string g in subset)
                Console.WriteLine($"Item: {g}");

            ReflectOverQueryResults(subset);
        }

        public static void QueryOverStringsWithExtensionMethods()
        {
            string[] currentVideoGames =
            {
                "Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"
            };

            IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" "))
                .OrderBy(g => g).Select(g => g);

            ReflectOverQueryResults(subset, "Extension methods");

            foreach (string g in subset)
                Console.WriteLine($"Item: {g}");
        }

        public static void QueryOverStringsLongHand ( )
        {
            Console.WriteLine("\n=> QueryOverStringsLongHand():");

            string[] currentVideoGames =
                    {
                "Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"
            };

            string[] gameWithSpaces = new string[5];

            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                {
                    gameWithSpaces[i] = currentVideoGames[i];
                }
            }

            Array.Sort(gameWithSpaces);

            foreach (string s in gameWithSpaces)
            {
                if (s != null)
                {
                    Console.WriteLine($"Item: {s}");
                }
            }

            Console.WriteLine();
        }

        public static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 60, 1, 3, 5, 7 };

            var subset = from i in numbers where i < 10 select i;

            foreach (var i in subset)
            {
                Console.WriteLine($"{i} < 10");
            }

            numbers[0] = 2;

            ReflectOverQueryResults(subset);

            foreach (var i in subset)
            {
                Console.WriteLine($"{i} < 10");
            }
        }

        public static void ImmediateExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 60, 1, 3, 5, 7 };

            int[] subsetAsIntArray = (from i in numbers where i < 10 select i).ToArray();
            List<int> subsetAsListOfInts = (from i in numbers where i < 10 select i).ToList();
            ReflectOverQueryResults(subsetAsIntArray, "ToArray()");
            ReflectOverQueryResults(subsetAsListOfInts, "ToList()");
        }

        public static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine($"\n***** Info about your query using {queryType} *****");
            Console.WriteLine($"resultSet is of type: {resultSet.GetType().Name}");
            Console.WriteLine($"resultSet location: {resultSet.GetType().Assembly.GetName().Name}\n");
        }
    }
}
