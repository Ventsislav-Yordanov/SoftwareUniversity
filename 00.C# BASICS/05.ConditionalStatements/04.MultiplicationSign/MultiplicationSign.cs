/*Write a program that shows the sign (+, - or 0) of the product of three real numbers,
 * without calculating it. Use a sequence of if operators. */
using System;

    class MultiplicationSign
    {
        static void Main()
        {
            Console.Write("Enter first number : ");
            double firstNumber = Double.Parse(Console.ReadLine());
            Console.Write("Enter second number : ");
            double secondNumber = Double.Parse(Console.ReadLine());
            Console.Write("Enter third number : ");
            double thirdNumber = Double.Parse(Console.ReadLine());

            if (firstNumber < 0)
            {
                if (secondNumber < 0)
                {
                    if (thirdNumber < 0)
                    {
                        Console.WriteLine("Result : -");
                    }
                    else if (thirdNumber > 0)
                    {
                        Console.WriteLine("Result : +");
                    }
                    else
                    {
                        Console.WriteLine("Result : 0");
                    }
                }
                else if (secondNumber > 0)
                {
                    if (thirdNumber < 0)
                    {
                        Console.WriteLine("Result : +");
                    }
                    else if (thirdNumber > 0)
                    {
                        Console.WriteLine("Result : -");
                    }
                    else
                    {
                        Console.WriteLine("Result : 0");
                    }
                }
            }
            else if (firstNumber > 0)
            {
                if (secondNumber < 0)
                {
                    if (thirdNumber < 0)
                    {
                        Console.WriteLine("Result : +");
                    }
                    else if (thirdNumber > 0)
                    {
                        Console.WriteLine("Result : -");
                    }
                    else
                    {
                        Console.WriteLine("Result : 0");
                    }
                }
                else if (secondNumber > 0)
                {
                    if (thirdNumber < 0)
                    {
                        Console.WriteLine("Result : -");
                    }
                    else if (thirdNumber> 0)
                    {
                        Console.WriteLine("Result : +");
                    }
                    else
                    {
                        Console.WriteLine("Result : 0");
                    }
                }
            }
            else
            {
                Console.WriteLine("Result : 0");
            }
        }
    }