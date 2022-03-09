using System;
using System.Linq;
using System.Collections.Generic;

namespace JoinCollectionApp
{
    record Person(string Name, string Company);
    record Company(string Title, string Language);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Join Collection *****");

            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
            };

            Company[] companies =
            {
                new Company("Microsoft", "C#"),
                new Company("Google", "Go"),
                new Company("Oracle", "Java"),
            };

            SimpleJoinOp(people, companies);
            SimpleJoinMet(people, companies);
            GroupJoinMet(people, companies);
            GroupJoinOp(people, companies);
        }

        static void SimpleJoinOp(IEnumerable<Person> people, IEnumerable<Company> companies)
        {
            Console.WriteLine("\n=> SimpleJoinOp():");

            var employees = from person in people
                            join company in companies on person.Company
                            equals company.Title
                            select new
                            {
                                Name = person.Name,
                                Company = company.Title,
                                Language = company.Language
                            };

            foreach (var employee in employees)
            {
                Console.WriteLine($"Name: {employee.Name}, Company: " +
                    $"{employee.Company}, Language: {employee.Language}");
            }
        }

        static void SimpleJoinMet(IEnumerable<Person> people, IEnumerable<Company> companies)
        {
            Console.WriteLine("\n=> SimpleJoinMet():");

            var employees = people.Join(companies,
                p => p.Company,
                c => c.Title,
                (p, c) => new
                {
                    p.Name,
                    Company = c.Title,
                    c.Language
                });

            foreach (var employee in employees)
            {
                Console.WriteLine($"Name: {employee.Name}, Company: " +
                    $"{employee.Company}, Language: {employee.Language}");
            }
        }

        static void GroupJoinMet(IEnumerable<Person> people, IEnumerable<Company> companies)
        {
            Console.WriteLine("\n=> GroupJoinMet():");

            var comps = companies.GroupJoin(people,
                c => c.Title,
                p => p.Company,
                (c, employees) => new
                    {
                        c.Title,
                        Employees = employees
                    });

            foreach (var company in comps)
            {
                Console.WriteLine(company.Title);

                foreach (var employee in company.Employees)
                {
                    Console.WriteLine(employee.Name);
                }

                Console.WriteLine();
            }
        }

        static void GroupJoinOp(IEnumerable<Person> people, IEnumerable<Company> companies)
        {
            Console.WriteLine("\n=> GroupJoinOp():");

            var comps = from comp in companies
                        join p in people on comp.Title equals p.Company into g
                        select new
                        {
                            comp.Title,
                            Employees = g
                        };

            foreach (var company in comps)
            {
                Console.WriteLine(company.Title);

                foreach (var employee in company.Employees)
                {
                    Console.WriteLine(employee.Name);
                }

                Console.WriteLine();
            }
        }
    }
}
