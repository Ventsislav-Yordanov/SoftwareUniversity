namespace Estates.Data
{
    using System;
    using Estates.Interfaces;

    public class House : Estate, IHouse
    {
        private const int minFloors = 0;
        private const int maxFloors = 10;

        private int floors;

        public House()
        {
            this.Type = EstateType.House;
        }

        public int Floors
        {
            get { return this.floors; }
            set
            {
                if (value < minFloors || value > maxFloors)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Floors must be in range [{0}...{1}]"));
                }

                this.floors = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Floors: {0}", this.Floors);
        }
    }
}
