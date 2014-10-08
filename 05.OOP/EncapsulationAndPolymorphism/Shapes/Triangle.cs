namespace Shapes
{
    using System;
    public class Triangle : BasicShape, IShape
    {
        private double thirdSide;

        public Triangle(double firstSide, double secondSide, double thirdSide)
            : base(firstSide, secondSide)
        {
            // check for valid triangle
            if (firstSide >= secondSide + thirdSide ||
                secondSide >= firstSide + thirdSide ||
                thirdSide >= firstSide + secondSide)
            {
                throw new ArithmeticException("Invalid triangle's sizes!");
            }

            this.ThirdSide = thirdSide;
        }

        public double ThirdSide
        {
            get { return this.thirdSide; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("ThirdSide cannot be negative or zero!");
                }

                this.thirdSide = value;
            }
        }

        public override double CalculateArea()
        {
            double p = (this.Height + this.Width + this.ThirdSide) / 2;
            double area = Math.Sqrt(p * (p - this.Height) * (p - this.Width) * (p - this.ThirdSide));
            return area;
        }

        public override double CalculatePerimeter()
        {
            var perimeter = this.Height + this.Width + this.ThirdSide;
            return perimeter;
        }
    }
}