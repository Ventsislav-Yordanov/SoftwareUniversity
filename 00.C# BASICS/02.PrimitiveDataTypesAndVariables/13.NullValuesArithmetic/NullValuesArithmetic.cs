/*Create a program that assigns null values to an integer and to a double variable.
 * Try to print these variables at the console.
 * Try to add some number or the null literal to these variables and print the result.*/
using System;
    class NullValuesArithmetic
    {
        static void Main()
        {
            int? nullableInt = null;
            double? nullableDouble = null;
            Console.WriteLine("Nullable int : {0}",nullableInt);
            Console.WriteLine("Nullable double : {0}", nullableDouble);
            Console.WriteLine();
            nullableInt = 65423;
            nullableDouble = 12321.5;
            Console.WriteLine();
            Console.WriteLine("Nullable int : {0}", nullableInt);
            Console.WriteLine("Nullable double : {0}", nullableDouble);
            nullableInt += null; // nullableInt += null E ЕКВИВАЛЕНТО НА nullableInt = nullableInt + null
            Console.WriteLine();
            Console.WriteLine("Nullable int : {0}", nullableInt);
        }
    }
