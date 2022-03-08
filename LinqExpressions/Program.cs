using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo{ Name = "Mac's Coffee",
                                Description = "Coffee with TEETH",
                                NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk",
                                Description = "Milk cow's love",
                                NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu",
                                Description = "Bland as Possible",
                                NumberInStock = 120},
                new ProductInfo{ Name = "Cruchy Pops",
                                Description = "Cheezy, peppery goodness",
                                NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water",
                                Description = "From the tap to your wallet",
                                NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza",
                                Description = "Everyone loves pizza!",
                                NumberInStock = 73}
            };

            List<string> cars1 = new List<String> { "Yugo", "Aztec", "BMW" };
            List<string> cars2= new List<String> { "BMW", "Saab", "Aztec" };

            Person[] people1 = { new Person("Nick"), new Person("Ruslan"), new Person("Henry") };
            Person[] people2 = { new Person("Nick"), new Person("Marcus") };

            ListProductNames(itemsInStock);
            Console.WriteLine();

            GetOverStock(itemsInStock);
            Console.WriteLine();

            GetNameAndDescriptions(itemsInStock);
            Console.WriteLine();

            GetCountFromQuery(itemsInStock);
            Console.WriteLine();

            ReverseEverything(itemsInStock);
            Console.WriteLine();

            AlphabetizeProductNames(itemsInStock);
            Console.WriteLine();

            DisplayDiff(cars1, cars2);
            Console.WriteLine();

            DisplayIntersection(cars1, cars2);
            Console.WriteLine();

            DisplayUnion(cars1, cars2);
            Console.WriteLine();
            
            DisplayConcat(cars1, cars2);
            Console.WriteLine();

            DisplayConcatNoDups(cars1, cars2);
            Console.WriteLine();

            DisplayUnionClass(people1, people2);
            Console.WriteLine();

            AggregateOps();
            Console.WriteLine();
        }

        static void ListProductNames(ProductInfo[] products)
        {
            Console.WriteLine("***** Only product names *****");

            var names = from p in products
                        select p.Name;

            foreach (var name in names)
            {
                Console.WriteLine($"Name: {name}");
            }
        }

        static void GetOverStock(ProductInfo[] products)
        {
            Console.WriteLine("***** The overstock items! *****");
            var overstock = from p in products
                            where p.NumberInStock > 25
                            select p;

            foreach (var p in overstock)
            {
                Console.WriteLine(p);
            }
        }

        static void GetNameAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("***** Names and Descriptions: *****");
            var nameDesc = from p in products
                           select new { p.Name, p.Description };

            foreach (var item in nameDesc)
            {
                Console.WriteLine(item);
            }
        }

        static void GetCountFromQuery(ProductInfo[] products)
        {
            int count = (from p in products
                            where p.NumberInStock >= 100
                            select p).Count();

            Console.WriteLine($"***** GetCountFromQuery(): {count} *****");
        }

        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("***** Product in reverse: *****");
            var prods = from p in products
                           select p;

            foreach (var item in prods.Reverse())
            {
                Console.WriteLine(item);
            }
        }

        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            Console.WriteLine("***** Ordered by name: *****");
            var subset = from p in products
                         orderby p.Name
                         select p;

            foreach (var p in subset)
            {
                Console.WriteLine(p);
            }
        }

        static void DisplayDiff(List<string> cars1, List<string> cars2)
        {
            Console.WriteLine("***** Diff: *****");
            var diff = (from c in cars1 select c).Except(from c in cars2 select c);

            foreach (var car in diff)
            {
                Console.WriteLine(car);
            }
        }

        static void DisplayIntersection(List<string> cars1, List<string> cars2)
        {
            Console.WriteLine("***** Intersection: *****");
            var diff = (from c in cars1 select c).Intersect(from c in cars2 select c);

            foreach (var car in diff)
            {
                Console.WriteLine(car);
            }
        }

        static void DisplayUnion(List<string> cars1, List<string> cars2)
        {
            Console.WriteLine("***** Union: *****");
            var diff = (from c in cars1 select c).Union(from c in cars2 select c);

            foreach (var car in diff)
            {
                Console.WriteLine(car);
            }
        }

        static void DisplayConcat(List<string> cars1, List<string> cars2)
        {
            Console.WriteLine("***** Concat: *****");
            var diff = (from c in cars1 select c).Concat(from c in cars2 select c);

            foreach (var car in diff)
            {
                Console.WriteLine(car);
            }
        }

        static void DisplayConcatNoDups(List<string> cars1, List<string> cars2)
        {
            Console.WriteLine("***** Distinct: *****");
            var diff = (from c in cars1 select c).Concat(from c in cars2 select c);

            foreach (var car in diff.Distinct())
            {
                Console.WriteLine(car);
            }
        }

        static void DisplayUnionClass(IEnumerable<Person> people1, IEnumerable<Person> people2)
        {
            Console.WriteLine("***** Union class Person: *****");
            var diff = people1.Union(people2);

            foreach (var person in diff)
            {
                Console.WriteLine(person.Name);
            }
        }

        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            Console.WriteLine($"Max temp: {(from t in winterTemps select t).Max()}");
            Console.WriteLine($"Min temp: {(from t in winterTemps select t).Min()}");
            Console.WriteLine($"Average temp: {(from t in winterTemps select t).Average()}");
            Console.WriteLine($"Sum temp: {(from t in winterTemps select t).Sum()}");
        }
    }
}
