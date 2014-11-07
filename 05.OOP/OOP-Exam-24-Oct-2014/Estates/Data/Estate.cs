namespace Estates.Data
{
    using System;
    using Estates.Interfaces;

    public class Estate : IEstate
    {
        private const int minArea = 0;
        private const int maxArea = 10000;

        private string name;
        private EstateType type;
        private double area;
        private string location;
        private bool isFurnished;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public EstateType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public double Area
        {
            get { return this.area; }
            set
            {
                if (value < minArea || value > maxArea)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Area must be in range [{0}...{1}]", minArea, maxArea));
                }

                this.area = value;
            }
        }

        public string Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public bool IsFurnished
        {
            get { return this.isFurnished; }
            set { this.isFurnished = value; }
        }

        public override string ToString()
        {
            return string.Format(
                "{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}",
                this.Type, this.Name, this.Area,
                this.Location, this.IsFurnished ? "Yes" : "No");
        }
    }
}
