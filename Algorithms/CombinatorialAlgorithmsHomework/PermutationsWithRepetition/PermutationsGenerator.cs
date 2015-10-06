namespace PermutationsWithRepetition
{
    using System;
    using System.Linq;

    public class PermutationsGenerator
    {
        public static void Main()
        {
            // Source: http://hardprogrammer.blogspot.bg/2006/11/permutaciones-con-repeticin.html 
            Console.Write("Please enter the numbers separated by space: ");
            var permutations = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            permutationsRep(permutations);
        }

        public static void permutationsRep(int[] permutations)
        {
            Array.Sort(permutations);
            Permute(permutations, 0, permutations.Length);
        }

        private static void Permute(int[] permutations, int start, int n)
        {
            Console.WriteLine(string.Join(", ", permutations));
            int temp = 0;

            if (start < n)
            {
                for (int i = n - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (permutations[i] != permutations[j])
                        {
                            // swap permutations[i] <--> permutations[j]
                            temp = permutations[i];
                            permutations[i] = permutations[j];
                            permutations[j] = temp;

                            Permute(permutations, i + 1, n);
                        }
                    }

                    // Undo all modifications done by
                    // recursive calls and swapping
                    temp = permutations[i];
                    for (int k = i; k < n - 1;)
                    {
                        permutations[k] = permutations[++k];
                    }

                    permutations[n - 1] = temp;
                }
            }
        }
    }
}
