namespace Shapes
{
    using System;
    public abstract class BasicShape : IShape
    {
        private double width;
        private double height;

        public BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be negative or zero!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be negative or zero!");
                }

                this.height = value; 
            }
        }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
}