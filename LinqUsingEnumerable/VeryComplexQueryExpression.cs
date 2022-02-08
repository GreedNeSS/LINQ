using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    class VeryComplexQueryExpression
    {
        public static void QueryStringsWithRawDelegates(string[] arr)
        {
            Console.WriteLine("=> VeryComplexQueryExpression.QueryStringsWithRawDelegates()");

            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProcess = new Func<string, string>(ToProcess);

            var subset = arr.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);

            foreach (var game in subset)
            {
                Console.WriteLine($"Item: {game}");
            }
        }

        static bool Filter(string str)
        {
            return str.Contains(" ");
        }

        static string ToProcess(string str)
        {
            return str;
        }
    }
}
