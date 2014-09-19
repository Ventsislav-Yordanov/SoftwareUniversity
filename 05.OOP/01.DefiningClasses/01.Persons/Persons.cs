using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Persons
{
    class Persons
    {
        static void Main()
        {
            List<Person> persons = new List<Person>(){
                    new Person("Dimitar", 20),
                    new Person("Alexander", 25, "alexKondov@abv.bg"),
                    new Person("Borko", 21, "Borko@abv.bg"),
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
