namespace NestedLoopsToRecursion
{
    using System;

    public class NestedLoopsToRecursionProgram
    {
        private static int Number;
        static void Gen01(int[] vector, int index = 0)
        {
            if (index >= vector.Length)
            {
                Print(vector);
            }
            else
            {
                for (int i = 1; i <= Number; i++)
                {
                    vector[index] = i;
                    Gen01(vector, index + 1);
                }
            }
        }

        static void Print(int[] vector)
        {
            foreach (int i in vector)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }

        public static void Main()
        {
            Console.Write("n = ");
            Number = int.Parse(Console.ReadLine());

            int[] vector = new int[Number];

            //Gen01(n - 1, vector);
            Gen01(vector);
        }
    }
}
