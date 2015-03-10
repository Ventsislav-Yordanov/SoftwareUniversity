namespace ConcurrentDatabaseChanges
{
    using System;
    using SoftUni.Entities;

    class ConcurrentDatabaseChangesClass
    {
        static void Main(string[] args)
        {
            using (SoftUniEntities softUniEntitiesFirst = new SoftUniEntities())
            {
                using (SoftUniEntities softUniEntitiesSecond = new SoftUniEntities())
                {
                    softUniEntitiesFirst.Addresses.Find(1).AddressText = "3290 All Ways Drive";
                    softUniEntitiesSecond.Addresses.Find(1).AddressText = "2237 Vine Lane";
                    softUniEntitiesFirst.SaveChanges();
                    softUniEntitiesSecond.SaveChanges();
                }
            }

            using (SoftUniEntities softUniEntities = new SoftUniEntities())
            {
                string addressText = softUniEntities.Addresses.Find(1).AddressText;
                Console.WriteLine(addressText);
            }
        }
    }
}
