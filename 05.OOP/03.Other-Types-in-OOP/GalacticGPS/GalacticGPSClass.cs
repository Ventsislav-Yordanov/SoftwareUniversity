using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticGPS
{
    class GalacticGPSClass
    {
        static void Main()
        {
            Location locationSaturn = new Location(18.1213, 12.343, Planet.Saturn);
            Location home = new Location(18.1213, 15.247, Planet.Earth);
            Location locationMars = new Location(28.3233, 12.343, Planet.Mars);
            Location locationMercury = new Location(19.13, 12.343, Planet.Mercury);
            Console.WriteLine(locationSaturn);
            Console.WriteLine(home);
            Console.WriteLine(locationMars);
            Console.WriteLine(locationMercury);
        }
    }
}
