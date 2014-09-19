using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02.LaptopShop
{
    class LaptopShop
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Battery batteryExample1 = new Battery("6-клетъчна");
            Battery batteryExample2 = new Battery("Ni-Cd", (float)4.5);

            Laptop laptopExample1 = new Laptop("ASUS N56JN-CN047D", 1899m);
            Laptop laptopExample2 = new Laptop(
                "ASUS N56JN-CN047D",
                1899m,
                "ASUS",
                "Intel Core i7-4700HQ (4-ядрен, 2.40 - 3.40 GHz, 6MB кеш)",
                "12GB (1x 8192MB + 1x 4096MB) - DDR3, 1600Mhz",
                "NVIDIA GeForce 840M (2GB DDR3)",
                "870GB (120GB SSD + 750GB HDD (7200 оборотa/минута))",
                "15.6-инчов (39.62 см.) - 1920x1080 (Full HD), матов",
                batteryExample2
                );
            Laptop laptopExample3 = new Laptop(model: "ASUS N56JN-CN047D", price: 2000m, graphicsCard: "NVIDIA GeForce 840M (2GB DDR3)");


            Console.WriteLine(laptopExample1.ToString());
            Console.WriteLine();
            Console.WriteLine(laptopExample2.ToString());
            Console.WriteLine();
            Console.WriteLine(laptopExample3.ToString());
        }
    }
}
