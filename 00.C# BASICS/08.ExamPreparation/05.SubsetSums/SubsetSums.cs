using System;

class BinaryDigitsCount
{
    static void Main(string[] args)
    {
        int goalBit = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int numOfGoalBits = 0;
            uint num = uint.Parse(Console.ReadLine());

            int firstNonZeroBit = 31;
            while ((num & (1 << firstNonZeroBit)) == 0)
            {
                firstNonZeroBit--;
            }
            while (firstNonZeroBit >= 0)
            {
                if ((num & 1) == goalBit)
                {
                    numOfGoalBits++;
                }
                num >>= 1;
                firstNonZeroBit--;
            }
            Console.WriteLine(numOfGoalBits);
        }
    }
}