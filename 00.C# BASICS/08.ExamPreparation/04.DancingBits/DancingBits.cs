using System;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int zerosCounter = 0;
        int onesCounter = 0;
        int sequencesCounter = 0;
        string countSwitcher = null;

        string result = null;

        if (n == 0)
        {
            Console.WriteLine(0);
            return;
        }

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            string tempResult = null;
            while (number > 0)
            {
                int lastBit = number & 1;
                tempResult = lastBit + tempResult;
                number = number >> 1;
            }
            result += tempResult;
        }

        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] == '0')
            {
                countSwitcher = "zero";
            }
            else
            {
                countSwitcher = "one";
            }

            if (countSwitcher == "zero")
            {
                zerosCounter++;

                if (i == result.Length - 1)
                {
                    if (zerosCounter == k)
                    {
                        sequencesCounter++;
                    }
                    break;
                }

                if (result[i + 1] == '1')
                {
                    if (zerosCounter == k)
                    {
                        sequencesCounter++;
                    }

                    zerosCounter = 0;
                }
            }

            if (countSwitcher == "one")
            {
                onesCounter++;

                if (i == result.Length - 1)
                {
                    if (onesCounter == k)
                    {
                        sequencesCounter++;
                    }

                    break;
                }

                if (result[i + 1] == '0')
                {
                    if (onesCounter == k)
                    {
                        sequencesCounter++;
                    }

                    onesCounter = 0;
                }
            }
        }
        Console.WriteLine(sequencesCounter);
    }
}