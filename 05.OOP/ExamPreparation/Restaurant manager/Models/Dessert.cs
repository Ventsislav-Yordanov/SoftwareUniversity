using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Dessert : Meal, IDessert
    {
        private bool withSugar;
        public Dessert(string name, decimal price, int calories, int quantity, MetricUnit unit, int time, bool isVegan, bool withSugar)
            : base(name, price, calories, quantity, unit, time, isVegan)
        {
            this.WithSugar = withSugar;
        }

        public bool WithSugar
        {
            get
            {
                return this.withSugar;
            }
            set
            {
                this.withSugar = value;
            }
        }

        public void ToggleSugar()
        {
            this.withSugar = !this.withSugar;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (!this.WithSugar)
            {
                result.Append("[NO SUGAR] ");
            }

            result.Append(base.ToString());
            return result.ToString();
        }
    }
}
