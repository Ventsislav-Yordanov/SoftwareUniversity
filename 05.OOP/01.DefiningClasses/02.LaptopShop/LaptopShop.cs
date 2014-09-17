using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LaptopShop
{
    class LaptopShop
    {
        static void Main(string[] args)
        {
            Battery firstBattery = new Battery("3-CELL LI-ION");
            Battery secondBattery = new Battery("Li-Ion, 4-cells", (float)3.5);

            Laptop laptopExample = new Laptop("Lenovo Yoga 2 Pro", (decimal)869.88, "Lenovo", 
                "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", "8 GB", "128GB SSD", 
                "Intel HD Graphics 4400", firstBattery, "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display");

            Laptop laptopExample2 = new Laptop("ASUS X551MA-SX169D", (decimal)499.00);

            Laptop laptopExample3 = new Laptop(model:"ASUS X502CA-XX007",price:(decimal)529, manufacturer:"Asus", 
                processor:"INTEL PENTIUM 987",hdd:"500 GB", battery: secondBattery);

            Console.WriteLine(laptopExample.ToString());
            Console.WriteLine();
            Console.WriteLine(laptopExample2.ToString());
            Console.WriteLine();
            Console.WriteLine(laptopExample3.ToString());
        }
    }
}
