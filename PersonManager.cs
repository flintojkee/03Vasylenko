using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Vasylenko
{
    public class PersonManager
    {
        public PersonManager()
        {
            new PersonRepository();
        }

        public bool Add(Person person)
        {
            return true;
        }
    }
}
