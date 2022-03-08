using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SortingWithLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person("Tom", 23, new List<string>{ "english", "german" }),
                new Person("Bob", 27, new List<string>{ "english", "french" }),
                new Person("Sam", 29, new List<string>{ "english", "spanish" }),
                new Person("Alice", 24, new List<string>{ "spanish", "german" }),
                new Person("Bob", 19, new List<string>{ "english" }),
                new Person("Sam", 20, new List<string>{ "spanish" }),
                new Person("Alice", 21, new List<string>{ "spanish" }),
            };

            string[] names = { "Ruslan", "Henry", "Bob", "Li" };

            List<Person> sortedList1 = MultiSort1(people);
            List<Person> sortedList2 = MultiSort2(people);
            List<string> listOfNames = LengthSort(names);

            Console.WriteLine("MultiSort1 => return\n");
            sortedList1.ForEach(p => Console.WriteLine($"Name: {p.Name}, Age: {p.Age}, Languages: {string.Join(", ", p.Languages)}"));

            Console.WriteLine("\nMultiSort2 => return\n");
            sortedList2.ForEach(p => Console.WriteLine($"Name: {p.Name}, Age: {p.Age}, Languages: {string.Join(", ", p.Languages)}"));

            Console.WriteLine("\nLengthSort => return\n");
            listOfNames.ForEach(n => Console.WriteLine(n));
        }

        public static List<Person> MultiSort1(List<Person> people)
        {
            var sortedList = from p in people
                         orderby p.Name, p.Age descending
                         select p;

            return sortedList.ToList();
        }

        public static List<Person> MultiSort2(List<Person> people)
        {
            var sortedList = people.OrderBy(p => p.Name).ThenByDescending(p => p.Age);

            return sortedList.ToList();
        }

        public static List<string> LengthSort(IEnumerable<string> array)
        {
            var list = array.OrderBy(p => p, new CustomStringComparer()).ToList();

            return list;
        }
    }
}
