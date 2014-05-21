/*Write a program that reads the radius r of a circle and prints its perimeter
 * and area formatted with 2 digits after the decimal point. */
using System;

    class CirclePerimeterAndArea
    {
        static void Main()
        {
            Console.Write("Enter radius : ");
            decimal radius = Decimal.Parse(Console.ReadLine());
            double pi = Math.PI;
            Console.WriteLine("Perimeter : {0:0.00}",2 *(decimal)pi * radius);
            Console.WriteLine("Area : {0:0.00}",(decimal)pi * radius * radius);
        }
    }