using System;

class BiggestTriple
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        string[] numbers = inputLine.Split(' ');
        int index = 0;
        int maxSum = Int32.MinValue;
        int bestStart = 0;
        int bestLen = 0;
        while (index < numbers.Length)
        {
            int num1 = int.Parse(numbers[index]);
            int len = 1;
            int num2 = 0;
            if (index + 1 < numbers.Length)
            {
                num2 = int.Parse(numbers[index + 1]);
                len = 2;
            }
            int num3 = 0;
            if (index + 2 < numbers.Length)
            {
                num3 = int.Parse(numbers[index + 2]);
                len = 3;
            }
            int sum = num1 + num2 + num3;
            if (sum > maxSum)
            {
                maxSum = sum;
                bestLen = len;
                bestStart = index;
            }
            index = index + 3;
        }

        // Print the result
        for (int i = 0; i < bestLen; i++)
        {
            Console.Write(numbers[bestStart]);
            bestStart++;
            if (i < bestLen - 1)
            {
                Console.Write(" ");
            }
        }
    }
}
