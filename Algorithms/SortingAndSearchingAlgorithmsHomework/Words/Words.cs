namespace Words
{
    using System;
    using System.Collections.Generic;

    public class Words
    {
        private static int wordsCount = 0;

        public static void Main()
        {
            char[] wordCharacters = Console.ReadLine().ToCharArray();
            Array.Sort(wordCharacters);
            GetAllValidWords(wordCharacters, 0);
            Console.WriteLine(wordsCount);
        }

        private static void GetAllValidWords(char[] wordCharacters, int startIndex)
        {
            if (IsValidWord(wordCharacters))
            {
                wordsCount++;
            }

            if (startIndex < wordCharacters.Length)
            {
                for (int firstIndex = wordCharacters.Length - 2; firstIndex >= startIndex; firstIndex--)
                {
                    for (int secondIndex = firstIndex + 1; secondIndex < wordCharacters.Length; secondIndex++)
                    {
                        if (wordCharacters[firstIndex] != wordCharacters[secondIndex])
                        {
                            Swap(ref wordCharacters[firstIndex], ref wordCharacters[secondIndex]);
                            GetAllValidWords(wordCharacters, firstIndex + 1);
                        }
                    }

                    char firstCharacter = wordCharacters[firstIndex];
                    for (int i = firstIndex; i < wordCharacters.Length - 1; i++)
                    {
                        wordCharacters[i] = wordCharacters[i + 1];
                    }

                    wordCharacters[wordCharacters.Length - 1] = firstCharacter;
                }
            }
        }

        private static bool IsValidWord(char[] word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
