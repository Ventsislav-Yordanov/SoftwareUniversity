using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LaptopShop
{
    public class Battery
    {
        private string type;
        private float hours;

        public Battery(string type)
        {
            this.Type = type;
        }

        public Battery(string type, float hours) : this(type)
        {
            this.Hours = hours;
        }

        public string Type
        {
            get { return this.type; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Invalid value for batrery type!");
                }
                this.type = value;
            }
        }

        public float Hours 
        {
            get { return this.hours; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid value for battery hours!");
                }
                this.hours = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.Type != null)
            {
                result.AppendLine("Battery : " + this.Type);
            }
            if (this.Hours > 0)
            {
                result.AppendLine("Battery life : " + this.Hours + " hours");
            }
            return result.ToString();
        }
    }
}
