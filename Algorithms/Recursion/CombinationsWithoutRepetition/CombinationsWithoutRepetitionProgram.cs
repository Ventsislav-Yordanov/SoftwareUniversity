namespace CombinationsWithoutRepetition
{
    using System;

    public class CombinationsWithoutRepetitionProgram
    {
        private const int StartNumber = 1;

        public static void Main()
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[] elements = new int[n];
            GenerateCombinations(elements, 0, StartNumber, k);
        }

        private static void GenerateCombinations(int[] elements, int index, int startNumber, int endNumber)
        {
            if (index >= elements.Length)
            {
                // A combination was found --> print it
                Console.WriteLine("(" + string.Join(", ", elements) + ")");
            }
            else
            {
                for (int currentNumber = startNumber; currentNumber <= endNumber; currentNumber++)
                {
                    elements[index] = currentNumber;
                    GenerateCombinations(elements, index + 1, currentNumber + 1, endNumber);
                }
            }
        }
    }
}
