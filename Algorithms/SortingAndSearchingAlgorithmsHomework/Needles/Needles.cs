namespace Needles
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.ReadLine();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var needles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] needlePositions = new int[needles.Length];
            for (int i = 0; i < needles.Length; i++)
            {
                int position = 0;
                while (position < numbers.Length && (needles[i] > numbers[position] || numbers[position] == 0))
                {
                    position++;
                }

                while (position > 0 && numbers[position - 1] == 0)
                {
                    position--;
                }

                needlePositions[i] = position;
            }

            Console.WriteLine(string.Join(" ", needlePositions));
        }
    }
}
