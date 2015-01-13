using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        private double heigth;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Heigth = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be zero or a negative number");
                }

                this.width = value;
            }
        }

        public double Heigth
        {
            get
            {
                return this.heigth;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Heigth cannot be zero or a negative number");
                }

                this.heigth = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Heigth);

            return perimeter;
        }

        public override double CalcArea()
        {
            double surface = this.Width * this.Heigth;

            return surface;
        }
    }
}
