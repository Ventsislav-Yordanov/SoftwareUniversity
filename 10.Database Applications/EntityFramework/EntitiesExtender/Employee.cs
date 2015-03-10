namespace EntitiesExtender
{
    using System.Data.Linq;

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
