/*Declare five variables choosing for each of them the most appropriate of the types
 * byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values:
 * 52130, -115, 4825932, 97, -10000.
 * Choose a large enough type for each number to ensure it will fit in it. 
 * Try to compile the code.*/
using System;

class DeclareVariables
    {
        static void Main()
        {
            ushort variable1 = 52130;
            sbyte variable2 = -115;
            int variable3 = 4825932;
            byte variable4 = 97;
            short variable5 = -10000;

            Console.WriteLine("Variable 1 is {0}", variable1);
            Console.WriteLine("Variable 2 is {0}", variable2);
            Console.WriteLine("Variable 3 is {0}", variable3);
            Console.WriteLine("Variable 4 is {0}", variable4);
            Console.WriteLine("Variable 5 is {0}", variable5);
        }
    }
