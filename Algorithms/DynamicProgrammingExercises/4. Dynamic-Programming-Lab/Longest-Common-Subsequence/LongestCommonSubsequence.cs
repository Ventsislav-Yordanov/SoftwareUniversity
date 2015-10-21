namespace Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestCommonSubsequence
    {
        public static void Main()
        {
            var firstStr = "GCCCTAGCG";
            var secondStr = "GCGCAATG";

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);
        }

        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            var lcsMatrix = new int[firstStr.Length + 1, secondStr.Length + 1];
            for (int i = 0; i < lcsMatrix.GetLength(0); i++)
            {
                lcsMatrix[i, 0] = 0;
            }

            for (int i = 0; i < lcsMatrix.GetLength(1); i++)
            {
                lcsMatrix[0, i] = 0;
            }

            for (int row = 1; row < lcsMatrix.GetLength(0); row++)
            {
                for (int col = 1; col < lcsMatrix.GetLength(1); col++)
                {
                    int maxLength = Math.Max(lcsMatrix[row - 1, col], lcsMatrix[row, col - 1]);
                    if (firstStr[row - 1] == secondStr[col - 1])
                    {
                        maxLength = Math.Max(maxLength, lcsMatrix[row - 1, col - 1] + 1);
                    }

                    lcsMatrix[row, col] = maxLength;
                }
            }

            return ReconstructLongestCommonSubsequence(firstStr, secondStr, lcsMatrix);
        }

        public static string ReconstructLongestCommonSubsequence(string firstStr, string secondStr, int[,] lcsMatrix)
        {
            var letters = new List<char>();
            int firstIndex = firstStr.Length;
            int secondIndex = secondStr.Length;
            while (firstIndex > 0 && secondIndex > 0)
            {
                if (firstStr[firstIndex - 1] == secondStr[secondIndex - 1] &&
                    lcsMatrix[firstIndex - 1, secondIndex - 1] + 1 == lcsMatrix[firstIndex, secondIndex])
                {
                    letters.Add(firstStr[firstIndex - 1]);
                    firstIndex--;
                    secondIndex--;
                }
                else if (lcsMatrix[firstIndex - 1, secondIndex] == lcsMatrix[firstIndex, secondIndex])
                {
                    firstIndex--;
                }
                else
                {
                    secondIndex--;
                }

            }

            letters.Reverse();
            return string.Join(string.Empty, letters);
        }
    }
}
