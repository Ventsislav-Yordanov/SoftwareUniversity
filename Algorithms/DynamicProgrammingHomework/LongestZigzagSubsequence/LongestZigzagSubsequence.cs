namespace LongestZigzagSubsequence
{
    using System;
    using System.Linq;

    public class LongestZigzagSubsequence
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the sequence: ");
            var sequence = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            var longestZigagSequence = FindLongestZigzagSubsequence(sequence);
            Console.WriteLine("Longest zigzag subsequence:");
            Console.WriteLine("Length: {0}", longestZigagSequence.Length);
            Console.WriteLine("Sequence: [{0}]", string.Join(", ", longestZigagSequence));
        }

        private static int[] FindLongestZigzagSubsequence(int[] sequence)
        {
            int[,] lengths = new int[2, sequence.Length];
            int[,] previousIndices = new int[2, sequence.Length];
            lengths[0, 0] = 1;
            lengths[1, 0] = 1;
            for (int i = 0; i < sequence.Length; i++)
            {
                previousIndices[0, i] = previousIndices[1, i] = -1;
            }

            for (int currentIndex = 1; currentIndex < sequence.Length; currentIndex++)
            {
                int previousLength = lengths[0, currentIndex - 1];
                lengths[0, currentIndex] = previousLength;
                if (previousLength % 2 != 0)
                {
                    if (sequence[currentIndex] < sequence[currentIndex - 1])
                    {
                        lengths[0, currentIndex] = previousLength + 1;
                    }
                }
                else
                {
                    if (sequence[currentIndex] > sequence[currentIndex - 1])
                    {
                        lengths[0, currentIndex] = previousLength + 1;
                    }
                }

                for (int previousIndex = currentIndex - 1; previousIndex >= 0; previousIndex--)
                {
                    if (lengths[0, currentIndex] == lengths[0, previousIndex] + 1)
                    {
                        if (lengths[0, currentIndex] % 2 == 0 && sequence[currentIndex] < sequence[previousIndex])
                        {
                            previousIndices[0, currentIndex] = previousIndex;
                        }
                        else if (lengths[0, currentIndex] % 2 != 0 && sequence[currentIndex] > sequence[previousIndex])
                        {
                            previousIndices[0, currentIndex] = previousIndex;
                        }
                    }
                }

                previousLength = lengths[1, currentIndex - 1];
                lengths[1, currentIndex] = previousLength;
                if (previousLength % 2 != 0)
                {
                    if (sequence[currentIndex] > sequence[currentIndex - 1])
                    {
                        lengths[1, currentIndex] = previousLength + 1;
                    }
                }
                else
                {
                    if (sequence[currentIndex] < sequence[currentIndex - 1])
                    {
                        lengths[1, currentIndex] = previousLength + 1;
                    }
                }

                for (int previousIndex = currentIndex - 1; previousIndex >= 0; previousIndex--)
                {
                    if (lengths[1, currentIndex] == lengths[1, previousIndex] + 1)
                    {
                        if (lengths[1, currentIndex] % 2 == 0 && sequence[currentIndex] > sequence[previousIndex])
                        {
                            previousIndices[1, currentIndex] = previousIndex;
                        }
                        else if (lengths[1, currentIndex] % 2 != 0 && sequence[currentIndex] < sequence[previousIndex])
                        {
                            previousIndices[1, currentIndex] = previousIndex;
                        }
                    }
                }
            }

            int[] previousIndicesToRestore;
            int maxIndex, maxLength;
            PrepareLongestZigZagSequenceToRestore(lengths, previousIndices, out previousIndicesToRestore, out maxIndex, out maxLength);

            return RestoreLongestZigzagSubsequence(sequence, previousIndicesToRestore, maxIndex, maxLength);
        }

        private static void PrepareLongestZigZagSequenceToRestore(int[,] lengths, int[,] previousIndices, out int[] previousIndicesToRestore, out int maxIndex, out int maxLength)
        {
            int[] maxLengths = { 0, 0 };
            int[] maxIndices = { 0, 0 };
            for (int i = 0; i < lengths.GetLength(0); i++)
            {
                for (int j = 0; j < lengths.GetLength(1); j++)
                {
                    if (lengths[i, j] > maxLengths[i])
                    {
                        maxLengths[i] = lengths[i, j];
                        maxIndices[i] = j;
                    }
                }
            }

            previousIndicesToRestore = new int[previousIndices.GetLength(1)];
            maxIndex = -1;
            maxLength = -1;
            if (maxLengths[0] > maxLengths[1])
            {
                for (int i = 0; i < previousIndices.GetLength(1); i++)
                {
                    previousIndicesToRestore[i] = previousIndices[0, i];
                }

                maxIndex = maxIndices[0];
                maxLength = maxLengths[0];
            }
            else
            {
                for (int i = 0; i < previousIndices.GetLength(1); i++)
                {
                    previousIndicesToRestore[i] = previousIndices[1, i];
                }

                maxIndex = maxIndices[1];
                maxLength = maxLengths[1];
            }
        }

        private static int[] RestoreLongestZigzagSubsequence(int[] sequence, int[] previousIndices, int maxIndex, int maxLength)
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
