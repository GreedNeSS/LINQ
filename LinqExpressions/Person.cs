using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExpressions
{
    class Person
    {
        public string Name { get; set; }

        public Person()
        {

        }

        public Person(string name)
        {
            Name = name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Person person = (Person)obj;
            return Name.Equals(person.Name);
        }
    }
}
