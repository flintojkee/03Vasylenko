using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Vasylenko
{ 
    public class PersonRepository
    {
        private static readonly List<Person> Persons = new List<Person>();

     
        internal void Add(Person person)
        {
            Persons.Add(person);
        }
    }
}
