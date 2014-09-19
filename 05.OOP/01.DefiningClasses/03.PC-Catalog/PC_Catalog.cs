using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PC_Catalog
{
    class PC_Catalog
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            // GRAPHICS CARDS
            Component graphicsCardRadeon = new Component("XFX Radeon HD 5450 1GB 64-bit DDR3", 51.22m);
            Component graphicsCardASUS = new Component("ASUS HD6450-SL-1GD3-BRK", 75.00m);
            Component graphicsCardGigabyte = new Component("Gigabyte GV-N660WF2-2GD", 345.00m);

            // PROCESSORS
            Component processorIntel = new Component("Intel Celeron G1820", 64.09m);
            Component processorAMD = new Component("AMD A4-Series X2 4020", 78.00m);
            Component processorIntelCorei5 = new Component("Intel Core i5-4460 (6M Cache, up to 3.40 GHz)", 360.00m);

            // MOTHERBOARDS
            Component motherboardASROCK = new Component("ASROCK AM1B-M", 50.00m);
            Component motherboardASROCK2 = new Component("ASROCK FM2A55M-VG3+", 81.00m);
            Component motherboardASUS = new Component("ASUS GRYPHON Z87", 263.00m);

            // COMPUTERS
            Computer computer1 = new Computer("Lenovo", new List<Component> { graphicsCardRadeon, processorIntel, motherboardASROCK });
            Computer computer2 = new Computer("ASUS", new List<Component> { graphicsCardASUS, processorAMD, motherboardASROCK2 });
            Computer computer3 = new Computer("ASUS", new List<Component> { graphicsCardGigabyte, processorIntelCorei5, motherboardASUS });

            List<Computer> computers = new List<Computer> { computer1, computer2, computer3 };

            computers.OrderByDescending(computer => computer.Price).ToList().ForEach(computer => Console.WriteLine(computer.ToString()));
        }
    }
}
