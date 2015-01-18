using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class MainCourse : Meal, IMainCourse
    {
        private MainCourseType type;

        public MainCourse(string name, decimal price, int calories, int quantity, MetricUnit unit, int time, bool isVegan, MainCourseType type)
            : base(name, price, calories, quantity, unit, time, isVegan)
        {
            this.Type = type;
        }

        public MainCourseType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Type: {0}", this.Type.ToString());
            return result.ToString();
        }
    }
}
