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
                    new Person("Ivan", 45),
                    new Person("Mitko", 24, "Dimitar@dir.bg"),
                    new Person("Petko", 14, "PeturPetrov@.dir.bg"),
            };
            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
