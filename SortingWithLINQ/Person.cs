using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingWithLINQ
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }

        public Person(string name, int age, List<string> langs)
        {
            Name = name;
            Age = age;
            Languages = langs;
        }
    }
}
