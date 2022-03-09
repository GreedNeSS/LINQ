using System;
using System.Linq;

namespace SkipAndTake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Skip and Take *****");

            string[] people = { "Tim", "Tom", "Ruslan", "Marcus", "Henry", "Bob" };

            Console.Write("\n=> Source: ");
            people.ToList().ForEach(p => Console.Write(p + " "));

            Console.Write($"\n\npeople.Skip(2).SkipLast(2): ");
            people.Skip(2).SkipLast(2).ToList().ForEach(p => Console.Write(p + " "));

            Console.Write($"\npeople.TakeLast(4).Take(2): ");
            people.TakeLast(4).Take(2).ToList().ForEach(p => Console.Write(p + " "));

            Console.Write($"\npeople.TakeWhile(p => p.Length == 3): ");
            people.TakeWhile(p => p.Length == 3).ToList().ForEach(p => Console.Write(p + " "));

            Console.Write($"\npeople.SkipWhile(p => p.Length == 3): ");
            people.SkipWhile(p => p.Length == 3).ToList().ForEach(p => Console.Write(p + " "));
        }
    }
}
