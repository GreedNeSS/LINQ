using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqOverCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
            };

            GetFastCar(cars);
            Console.WriteLine();

            GetFastBMWs(cars);
            Console.WriteLine();

            LINQOverArrayList(cars);
            Console.WriteLine();

            OfTypeAsFilter(cars);
            Console.WriteLine();
        }

        static void GetFastCar(List<Car> cars)
        {
            var subset = from c in cars
                         where c.Speed > 55
                         select c;

            foreach (var c in subset)
            {
                Console.WriteLine($"{c.PetName} is going too fast!");
            }
        }

        static void GetFastBMWs(List<Car> cars)
        {
            var subset = from c in cars
                         where c.Speed > 90 && c.Make == "BMW"
                         select c;

            foreach (var c in subset)
            {
                Console.WriteLine($"{c.PetName} is going too fast!");
            }
        }

        static void LINQOverArrayList(List<Car> cars)
        {
            ArrayList al = new();
            foreach (var car in cars)
            {
                al.Add(car);
            }

            var myCarEnum = al.OfType<Car>();

            var subset = from c in myCarEnum
                         where c.Speed > 50
                         select c;

            foreach (Car c in subset)
            {
                Console.WriteLine($"Name: {c.PetName}, Make: {c.Make}, Speed: {c.Speed}");
            }
        }

        static void OfTypeAsFilter(List<Car> cars)
        {
            ArrayList al = new();
            al.AddRange(cars);
            al.AddRange(new int[] { 1, 2, 3, 56, 345, 12 });
            al.AddRange(new string[] { "hello", "world", "name" });

            var strings = al.OfType<string>();

            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }
        }
    }
}
