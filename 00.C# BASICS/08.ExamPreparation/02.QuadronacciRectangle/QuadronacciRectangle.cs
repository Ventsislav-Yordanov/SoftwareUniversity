using System;

public class Program
{
    public static void Main()
    {
        long n0 = long.Parse(Console.ReadLine());
        long n1 = long.Parse(Console.ReadLine());
        long n2 = long.Parse(Console.ReadLine());
        long n3 = long.Parse(Console.ReadLine());
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        long result = 0;

        Console.Write("{0} {1} {2} {3} ", n0, n1, n2, n3);  //starting first row
        if (cols == 4)
        {
            Console.WriteLine();
        }

        for (int i = 4; i < cols; i++)   //finishing first row
        {
            result = n0 + n1 + n2 + n3;
            if (i == cols - 1)
            {
                Console.Write(result);
                Console.WriteLine();
                n0 = n1;
                n1 = n2;
                n2 = n3;
                n3 = result;
                break;
            }
            Console.Write(result + " ");
            n0 = n1;
            n1 = n2;
            n2 = n3;
            n3 = result;
        }

        for (int i = 0; i < rows - 1; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result = n0 + n1 + n2 + n3;
                if (j == cols - 1)
                {
                    Console.Write(result);
                    Console.WriteLine();
                    n0 = n1;
                    n1 = n2;
                    n2 = n3;
                    n3 = result;
                    break;
                }
                Console.Write(result + " ");
                n0 = n1;
                n1 = n2;
                n2 = n3;
                n3 = result;
            }
        }
    }
}
