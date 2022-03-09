using System;
using System.Linq;
using System.Collections.Generic;

namespace GroupByApp
{
    public record Person(string Name, string Company);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Group By App *****");

            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
            };

            SimpleGroupByOp(people);
            //SimpleGroupByMet(people);
            CreateNewObj(people);
            CreateSubqueryMet(people);
            CreateSubqueryOp(people);

        }

        public static void SimpleGroupByOp(IEnumerable<Person> people)
        {
            Console.WriteLine("=> SimpleGroupByOp:");

            var companies = from p in people
                            group p by p.Company;

            foreach (var comp in companies)
            {
                Console.WriteLine($"Company: {comp.Key}");

                foreach (var employee in comp)
                {
                    Console.WriteLine(employee.Name);
                }

                Console.WriteLine();
            }
        }

        public static void SimpleGroupByMet(IEnumerable<Person> people)
        {
            Console.WriteLine("=> SimpleGroupByMet:");

            var companies = people.GroupBy(p => p.Company);

            foreach (var comp in companies)
            {
                Console.WriteLine($"Company: {comp.Key}");

                foreach (var employee in comp)
                {
                    Console.WriteLine(employee.Name);
                }

                Console.WriteLine();
            }
        }

        public static void CreateNewObj(IEnumerable<Person> people)
        {
            Console.WriteLine("=> CreateNewObj:");

            var companies = from person in people
                            group person by person.Company into g
                            select new { Company = g.Key, Count = g.Count() };

            foreach (var comp in companies)
            {
                Console.WriteLine($"Company: {comp.Company}, Count: {comp.Count}");
                Console.WriteLine();
            }
        }

        public static void CreateSubqueryMet(IEnumerable<Person> people)
        {
            Console.WriteLine("=> CreateSubqueryMet:");

            var companies = people.GroupBy(p => p.Company).Select(
                c => new { Company = c.Key, Count = c.Count(), Employees = c.Select(p => p) });

            foreach (var comp in companies)
            {
                Console.WriteLine($"Company: {comp.Company}");

                foreach (var employee in comp.Employees)
                {
                    Console.WriteLine(employee.Name);
                }

                Console.WriteLine();
            }
        }

        public static void CreateSubqueryOp(IEnumerable<Person> people)
        {
            Console.WriteLine("=> CreateSubqueryOp:");

            var companies = from person in people
                            group person by person.Company into g
                            select new
                            {
                                Company = g.Key,
                                Employees = from p in g
                                            select p
                            };

            foreach (var comp in companies)
            {
                Console.WriteLine($"Company: {comp.Company}");

                foreach (var employee in comp.Employees)
                {
                    Console.WriteLine(employee.Name);
                }

                Console.WriteLine();
            }
        }
    }
}
