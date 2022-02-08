using System;
using System.Linq;

namespace LinqUsingEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};

            QueryStringWithOperators(currentVideoGames);
            Console.WriteLine();

            QueryStringWithEnumerableAndLambdas(currentVideoGames);
            Console.WriteLine();

            QueryStringWithEnumerableAndLambdas2(currentVideoGames);
            Console.WriteLine();

            QueryStringsWithAnonymousMethods(currentVideoGames);
            Console.WriteLine();

            VeryComplexQueryExpression.QueryStringsWithRawDelegates(currentVideoGames);
            Console.WriteLine();
        }

        static void QueryStringWithOperators(string[] arr)
        {
            Console.WriteLine("=> QueryStringWithOperators()");

            var subset = from game in arr
                         where game.Contains(" ")
                         orderby game
                         select game;

            foreach (var game in subset)
            {
                Console.WriteLine($"Item: {game}");
            }
        }

        static void QueryStringWithEnumerableAndLambdas(string[] arr)
        {
            Console.WriteLine("=> QueryStringWithEnumerableAndLambdas()");

            var subset = arr.Where(g => g.Contains(" ")).OrderBy(i => i).Select(item => item);

            foreach (var game in subset)
            {
                Console.WriteLine($"Item: {game}");
            }
        }

        static void QueryStringWithEnumerableAndLambdas2(string[] arr)
        {
            Console.WriteLine("=> QueryStringWithEnumerableAndLambdas2()");

            var gamesWithSpaces = arr.Where(game => game.Contains(" "));
            var orderedGames = gamesWithSpaces.OrderBy(game => game);
            var subset = orderedGames.Select(game => game);

            foreach (var game in subset)
            {
                Console.WriteLine($"Item3: {game}");
            }
        }

        static void QueryStringsWithAnonymousMethods(string[] arr)
        {
            Console.WriteLine("=> QueryStringsWithAnonymousMethods()");

            Func<string, bool> searchFilter = delegate (string str)
            {
                return str.Contains(" ");
            };

            Func<string, string> itemToProcess = delegate (string str)
            {
                return str;
            };

            var subset = arr.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);

            foreach (var game in subset)
            {
                Console.WriteLine($"Item: {game}");
            }
        }
    }
}
