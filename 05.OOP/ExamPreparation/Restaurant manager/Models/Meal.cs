using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Meal : Recipe, IMeal
    {
        private bool isVegan;

        public Meal(string name, decimal price, int calories, int quantity, MetricUnit unit, int time, bool isVegan)
            :base(name, price, calories, quantity, unit, time)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan
        {
            get
            {
                return this.isVegan;
            }
            set
            {
                this.isVegan = value;
            }
        }

        public void ToggleVegan()
        {
            this.isVegan = !this.isVegan;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (this.IsVegan)
            {
                result.Append("[VEGAN] ");
            }

            result.Append(base.ToString());
            return result.ToString();
        }
    }
}
