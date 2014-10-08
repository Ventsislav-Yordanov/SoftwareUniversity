using System;
using System.Collections.Generic;

namespace Shapes
{
    public class TestShapes
    {
        static void Main(string[] args)
        {
            IShape triangle1 = new Triangle(9.5, 2, 10);
            IShape triangle2 = new Triangle(10.5, 4, 10);

            IShape rectangle1 = new Rectangle(2.5, 3);
            IShape rectangle2 = new Rectangle(4.5, 5);

            IShape circle1 = new Circle(2.6);
            IShape circle2 = new Circle(3.5);

            List<IShape> shapes = new List<IShape>() 
            { 
                triangle1,
                triangle2,
                rectangle1,
                rectangle2,
                circle1,
                circle2 
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Shape Name: {0}, Perimeter: {1:F2}, Area: {2:F2}",
                    shape.GetType().Name,
                    shape.CalculatePerimeter(),
                    shape.CalculateArea());
            }
        }
    }
}