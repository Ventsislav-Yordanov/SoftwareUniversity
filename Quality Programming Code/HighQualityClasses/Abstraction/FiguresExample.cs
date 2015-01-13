using System;

namespace Abstraction
{
    public class FiguresExample
    {
        static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine(circle.ToString());
            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(rect.ToString());
        }
    }
}
