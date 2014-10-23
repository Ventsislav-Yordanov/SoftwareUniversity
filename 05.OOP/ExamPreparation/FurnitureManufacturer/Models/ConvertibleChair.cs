using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10m;
        private bool isConverted = false;
        private decimal initialHeight;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.initialHeight = height;
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
        }

        public void Convert()
        {
            if (isConverted)
            {
                // Converted --> Normal
                this.Height = this.initialHeight;
                this.isConverted = false;
            }
            else
            {
                // Normal --> Converted
                this.Height = ConvertedHeight;
                this.isConverted = true;
            }
        }

        public override string ToString()
        {
            return 
                base.ToString() + 
                ", State: " + (this.IsConverted ? "Converted" : "Normal");
        }
    }
}
