/*Write an expression that calculates rectangle’s perimeter and area by given width and height. */
using System;

    class Rectangles
    {
        static void Main()
        {
            Console.Write("Enter width : ");
            double width = Double.Parse(Console.ReadLine());

            Console.Write("Enter height : ");
            double height = Double.Parse(Console.ReadLine());

            Console.WriteLine("Perimeter {0}",2*(width + height));
            Console.WriteLine("Area : {0}", width * height);
        }
    }