/*The gravitational field of the Moon is approximately 17% of that on the Earth.
 * Write a program that calculates the weight of a man on the moon by a given weight on the Earth*/
using System;
    class GravitationOnTheMoon
    {
        static void Main()
        {
            Console.Write("Enter weight of a man : ");
            double WeightMan = double.Parse(Console.ReadLine());

            Console.WriteLine("The weight of a man on the moon is : {0}", WeightMan * 17 / 100);
        }
    }