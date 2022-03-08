using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionFiltering
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people1 = new List<Person>()
            {
                new Person("Tom", 23, new List<string>{ "english", "german" }),
                new Person("Bob", 27, new List<string>{ "english", "french" }),
                new Person("Sam", 29, new List<string>{ "english", "spanish" }),
                new Person("Alice", 24, new List<string>{ "spanish", "german" }),
            };

            List<Person> people2 = new List<Person>()
            {
                new Student("Henry", 18, new List<string>{ "english", "german" }),
                new Person("Bob", 27, new List<string>{ "english", "french" }),
                new Student("Samuel", 19, new List<string>{ "english", "spanish" }),
                new Employee("Alice", 24, new List<string>{ "spanish", "german" }),
            };

            List<Person> subList1 = FilteringListByLang1(people1);
            List<Person> subList2 = FilteringListByLang2(people1);
            List<Person> subList3 = FilteringListByType(people2);

            Console.WriteLine("FilteringListByLang() => return \n");

            subList1.ForEach(p => Console.WriteLine($"Name: {p.Name}, Age: {p.Age}" +
                $", Languages: {string.Join(", ", p.Languages)}"));

            Console.WriteLine("\nFilteringListByLang() => return \n");

            subList2.ForEach(p => Console.WriteLine($"Name: {p.Name}, Age: {p.Age}" +
                $", Languages: {string.Join(", ", p.Languages)}"));

            Console.WriteLine("\nFilteringListByType() => return \n");

            subList3.ForEach(p => Console.WriteLine($"Name: {p.Name}, Age: {p.Age}" +
                $", Languages: {string.Join(", ", p.Languages)}"));
        }

        static List<Person> FilteringListByLang1(List<Person> people)
        {
            var subList = from p in people
                          from lang in p.Languages
                          where p.Age < 28
                          where lang == "english"
                          select p;

            return subList.ToList();
        }

        static List<Person> FilteringListByLang2(List<Person> people)
        {
            var subList = people.SelectMany(
                p => p.Languages,
                (p, l) => new { Person = p, Languages = l })
                .Where(i => i.Languages == "english" && i.Person.Age < 28)
                .Select(p => p.Person)
                .ToList<Person>();

            return subList.ToList();
        }

        static List<Person> FilteringListByType(List<Person> people)
        {
            var subList = people.OfType<Student>();

            return subList.ToList<Person>();
        }
    }
}
