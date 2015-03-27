namespace ListContinents
{
    using System;

    using Geography.Entities;

    class ListContinents
    {
        static void Main()
        {
            var context = new GeographyEntities();
            Console.WriteLine("Continents:");
            foreach (var continent in context.Continents)
            {
                Console.WriteLine(continent.ContinentName);
            }
        }
    }
}
