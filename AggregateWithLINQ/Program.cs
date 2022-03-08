using System;
using System.Linq;
using System.Collections.Generic;

namespace AggregateWithLINQ
{

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
       
        public Person()
        {

        }

        public Person(string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Salary: {Salary}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Aggregate With LINQ *****");

            Person[] people =
            {
                new Person("Tom", 23, 3000),
                new Person("Bob", 27, 5000),
                new Person("Sam", 29, 5500),
                new Person("Alice", 24, 3500),
            };

            people.ToList().ForEach(p => Console.WriteLine(p));

            Console.WriteLine($"\npeople.Count(): {people.Count()}");
            Console.WriteLine($"people.Sum(p => p.Salary): {people.Sum(p => p.Salary)}");
            Console.WriteLine($"people.Max(p => p.Salary): {people.Max(p => p.Salary)}");
            Console.WriteLine($"people.Min(p => p.Age): {people.Min(p => p.Age)}");
            Console.WriteLine($"people.Average(p => p.Age): {people.Average(p => p.Age)}");
            Console.WriteLine($"people.Average(p => p.Age): {people.Average(p => p.Salary)}");
            Console.WriteLine("people.Select(p => p.Name).Aggregate(\"Names: \"," +
                " (first, second) => $\"{first} {second}\")\n => \n" +
                people.Select(p => p.Name).Aggregate("Names:", (first, second) => $"{first} {second}"));
        }
    }
}
