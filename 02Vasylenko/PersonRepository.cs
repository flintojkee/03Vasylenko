using System.Collections.Generic;

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
