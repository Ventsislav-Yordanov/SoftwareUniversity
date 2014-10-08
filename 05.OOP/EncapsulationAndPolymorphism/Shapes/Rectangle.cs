namespace Shapes
{
    public class Rectangle : BasicShape, IShape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {

        }

        public override double CalculateArea()
        {
            double area = this.Width * this.Height;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * this.Width + 2 * this.Height;
            return perimeter;
        }
    }
}