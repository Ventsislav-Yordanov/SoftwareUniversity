using System;

class AngryFemaleGPS
{
    static void Main()
    {
        string cordinateString = Console.ReadLine();
        long countOdd = 0;
        long countEven = 0;

        for (int i = 0; i < cordinateString.Length; i++)
        {
            if (char.IsDigit(cordinateString[i]))
            {
                if (long.Parse(cordinateString[i].ToString()) % 2 == 1)
                {
                    countOdd += long.Parse(cordinateString[i].ToString());
                }
                else
                {
                    countEven += long.Parse(cordinateString[i].ToString());
                }
            }
        }

        if (countEven > countOdd)
        {
            Console.WriteLine("right {0}", countEven);
        }
        else if (countOdd > countEven)
        {
            Console.WriteLine("left {0}", countOdd);
        }
        else
        {
            Console.WriteLine("straight {0}", countOdd);
        }
    }
}