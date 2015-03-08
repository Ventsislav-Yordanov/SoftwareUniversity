using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUni.Entities;

namespace ConcurrentDatabaseChanges
{
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
