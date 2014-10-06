namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class TestAnimals
    {
        static void Main(string[] args)
        {
            Cat kitty = new Cat("Kitty", 5, Genders.Female);
            Tomcat charlie = new Tomcat("Charlie", 20, Genders.Male);
            Kitten ellie = new Kitten("Ellie", 1, Genders.Female);

            Dog ares = new Dog("Ares", 2, Genders.Male);
            Dog rocky = new Dog("Rocky", 5, Genders.Male);
            Dog daisy = new Dog("Daisy", 5, Genders.Female);

            Frog casper = new Frog("Casper", 3, Genders.Male);
            Frog abby = new Frog("Abby", 2, Genders.Female);

            List<Animal> animals = new List<Animal>()
            {
                kitty,
                charlie,
                ellie,
                ares,
                rocky,
                daisy,
                casper,
                abby
            };

            var groupedAnimals = from animal in animals
                                 group animal by (animal is Cat) ? typeof(Cat) : animal.GetType() into g
                                 select new { GroupName = g.Key, AverageAge = g.ToList().Average(animal => animal.Age) };

            foreach (var animal in groupedAnimals)
            {
                Console.WriteLine("{0} - average age : {1:F2}", animal.GroupName.Name, animal.AverageAge);
            }
        }
    }
}
