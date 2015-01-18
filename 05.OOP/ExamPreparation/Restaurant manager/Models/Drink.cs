using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Drink: Recipe, IDrink
    {
        private bool isCarbonated;

        public Drink(string name, decimal price, int calories, int quantity, MetricUnit unit, int time, bool isCarbonated)
            :base(name, price, calories, quantity, unit, time)
        {
            this.IsCarbonated = isCarbonated;
        }

        public bool IsCarbonated
        {
            get
            {
                return this.isCarbonated;
            }
            set
            {
                this.isCarbonated = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Carbonated: {0}", this.IsCarbonated ? "yes" : "no");
            return result.ToString();
        }
    }
}
