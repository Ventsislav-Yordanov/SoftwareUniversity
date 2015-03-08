using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUni.Entities;
using System.Data.Linq;

namespace EntitiesExtender
{
    public partial class Employee
    {
        private EntitySet<Territory> territories;

        public virtual EntitySet<Territory> Territories
        {
            get { return this.territories; }
            set { this.territories = value; }
        }

        public Employee()
        {
            this.Territories = new EntitySet<Territory>();
        }
    }
}
