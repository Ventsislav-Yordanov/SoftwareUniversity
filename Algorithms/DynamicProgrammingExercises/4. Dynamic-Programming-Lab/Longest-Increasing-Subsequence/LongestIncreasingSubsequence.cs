namespace Longest_Increasing_Subsequence
{
    using System;
    using System.Linq;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the sequence: ");
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var longestSequence = FindLongestIncreasingSubsequence(sequence);
            Console.WriteLine("Longest increasing subsequence (LIS)");
            Console.WriteLine("Length: {0}", longestSequence.Length);
            Console.WriteLine("Sequence: [{0}]", string.Join(", ", longestSequence));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] sequence)
        {
            int[] lengths = new int[sequence.Length];
            int[] previousIndices = new int[sequence.Length];
            for (int currentIndex = 0; currentIndex < sequence.Length; currentIndex++)
            {
                lengths[currentIndex] = 1;
                previousIndices[currentIndex] = -1;
                for (int previousIndex = currentIndex - 1; previousIndex >= 0; previousIndex--)
                {
                    if (sequence[previousIndex] < sequence[currentIndex] && lengths[previousIndex] + 1 >= lengths[currentIndex])
                    {
                        lengths[currentIndex] = lengths[previousIndex] + 1;
                        previousIndices[currentIndex] = previousIndex;
                    }
                }
            }

            int maxLength = 0;
            int maxIndex = 0;
            for (int i = 0; i < lengths.Length; i++)
            {
                if (lengths[i] > maxLength)
                {
                    maxLength = lengths[i];
                    maxIndex = i;
                }
            }

            return RestoreLongestIncreasingSubsequence(sequence, previousIndices, maxIndex, maxLength);
        }

        private static int[] RestoreLongestIncreasingSubsequence(int[] sequence, int[] previousIndices, int maxIndex, int maxLength)
        {
            int[] restoredSequence = new int[maxLength];
            if (maxLength == 0)
            {
                return restoredSequence;
            }

            int index = maxLength - 1;
            do
            {
                restoredSequence[index] = sequence[maxIndex];
                index--;
                maxIndex = previousIndices[maxIndex];
            }
            while (maxIndex != -1);

            return restoredSequence;
        }
    }
}
