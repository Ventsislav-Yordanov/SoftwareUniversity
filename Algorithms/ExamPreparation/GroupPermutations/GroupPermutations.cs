namespace GroupPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GroupPermutations
    {
        private static Dictionary<char, int> letterCount;
        private static Dictionary<char, string> letterString;
        private static char[] letters;
        private static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            letters = Console.ReadLine().ToCharArray();
            letterCount = new Dictionary<char, int>();
            letterString = new Dictionary<char, string>();
            foreach (var letter in letters)
            {
                if (letterCount.ContainsKey(letter))
                {
                    letterCount[letter]++;
                }
                else
                {
                    letterCount[letter] = 1;
                }
            }
            foreach (var letter in letters)
            {
                if (!letterString.ContainsKey(letter))
                {
                    letterString[letter] = new string(letter, letterCount[letter]);
                }
            }

            letters = letters.Distinct().ToArray();
            GeneratePermutations(letters, 0);

            // Remove empty line at the end on result
            result.Length = result.Length - 2;
            Console.WriteLine(result);
        }

        private static void GeneratePermutations(char[] letters, int index)
        {
            if (index >= letters.Length)
            {
                GenerateResult(letters);
            }
            else
            {
                GeneratePermutations(letters, index + 1);
                for (int i = index + 1; i < letters.Length; i++)
                {
                    Swap(index, i);
                    GeneratePermutations(letters, index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void GenerateResult(char[] letters)
        {
            foreach (var letter in letters)
            {
                result.Append(letterString[letter]);
            }

            result.AppendLine();
        }

        private static void Swap(int firstIndex, int secondIndex)
        {
            var oldFirst = letters[firstIndex];
            letters[firstIndex] = letters[secondIndex];
            letters[secondIndex] = oldFirst;
        }
    }
}
