/*Which of the following values can be assigned to a variable of type float and which to a variable 
 * of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
 * Write a program to assign the numbers in variables and print them to ensure no precision is lost.*/
using System;

class FloatOrDouble
{
    static void Main()
    {
        double value1 = 34.567839023d;
        float value2 = 12.345f;
        double value3 = 8923.1234857d;
        float value4 = 3456.091f;

        Console.WriteLine("Value 1 : {0}",value1);
        Console.WriteLine("Value 2 : {0}", value2);
        Console.WriteLine("Value 3 : {0}", value3);
        Console.WriteLine("Value 4 : {0}", value4);
    }
}
