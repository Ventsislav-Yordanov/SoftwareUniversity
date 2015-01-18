using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Salad: Meal, ISalad
    {
        private bool containsPasta;

        public Salad(string name, decimal price, int calories, int quantity, MetricUnit unit, int time, bool isVegan, bool containsPasta)
            : base(name, price, calories, quantity, unit, time, true)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta
        {
            get
            {
                return this.containsPasta;
            }
            set
            {
                this.containsPasta = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Contains pasta: {0}", this.ContainsPasta ? "yes" : "no");
            return result.ToString();
        }
    }
}
