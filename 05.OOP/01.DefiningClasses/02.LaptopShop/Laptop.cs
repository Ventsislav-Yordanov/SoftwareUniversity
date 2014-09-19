using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LaptopShop
{
    public class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private string ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery battery;
        private decimal price;

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The model cannot be empty or null!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid value for manufacturer!");
                }
                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid value for processor!");
                }
                this.processor = value;
            }
        }

        public string RAM
        {
            get { return this.ram; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid value for RAM!");
                }
                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get { return this.graphicsCard; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid value for graphics card!");
                }
                this.graphicsCard = value;
            }
        }

        public string HDD
        {
            get { return this.hdd; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid value for HDD!");
                }
                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid value for screen!");
                }
                this.screen = value;
            }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative!");
                }
                this.price = value;
            }
        }

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, string manufacturer = null, string processor = null, string RAM = null, 
            string graphicsCard = null, string HDD = null, string screen = null, Battery battery = null)
            : this(model, price) 
        {
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.RAM = ram;
            this.GraphicsCard = graphicsCard;
            this.HDD = hdd;
            this.Screen = screen;
            this.Battery = battery;
        }

        public override string ToString()
        {
            StringBuilder laptopInfo = new StringBuilder();
            laptopInfo.AppendLine("Model : " + this.Model);

            if (this.Manufacturer != null)
            {
                laptopInfo.AppendLine("Manufacturer : " + this.Manufacturer);
            }

            if (this.Processor != null)
            {
                laptopInfo.AppendLine("Processor : " + this.Processor);
            }

            if (this.RAM != null)
            {
                laptopInfo.AppendLine("RAM : " + this.RAM);
            }

            if (this.GraphicsCard != null)
            {
                laptopInfo.AppendLine("Graphics card : " + this.GraphicsCard);
            }

            if (this.HDD != null)
            {
                laptopInfo.AppendLine("HDD : " + this.HDD);
            }

            if (this.Screen != null)
            {
                laptopInfo.AppendLine("Screen : " + this.Screen);
            }

            if (this.Battery != null)
            {
                laptopInfo.Append("Battery : " + this.Battery);
            }

            laptopInfo.Append("Price : " + this.Price + " lv.");

            return laptopInfo.ToString();
        }
    }
}
