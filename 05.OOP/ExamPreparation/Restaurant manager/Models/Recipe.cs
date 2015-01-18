using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int quantity;
        private MetricUnit unit;
        private int time;

        public Recipe(string name,decimal price, int calories, int quantity, MetricUnit unit, int time)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantity;
            this.Unit = unit;
            this.TimeToPrepare = time;
            
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public Decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public int Calories
        {
            get
            {
                return this.calories;
            }
            set
            {
                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public MetricUnit Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }

        public int TimeToPrepare
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("==  {0} == ${1:F2}", this.Name, this.Price).AppendLine()
                .AppendFormat("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing, this.GetUnitString(), this.Calories).AppendLine()
                .AppendFormat("Ready in {0} minutes", this.TimeToPrepare);
            return result.ToString();
        }

        private string GetUnitString()
        {
            switch (this.Unit)
            {
                case MetricUnit.Grams:
                    return "g";
                case MetricUnit.Milliliters:
                    return "ml";
                default:
                    throw new InvalidOperationException("Invalid type of unit selected.");
            }
        }
    }
}
