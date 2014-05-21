/*Write a program that, depending on the user’s choice, inputs an int, double or string variable.
 * If the variable is int or double, the program increases it by one.
 * If the variable is a string, the program appends "*" at the end. Print the result at the console.
 * Use switch statement. */
using System;

    class PlayWithIntDoubleAndString
    {
        static void Main()
        {
            Console.WriteLine("Please choose a type:");
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");

            Console.Write("Your choose : ");
            int choose = Int32.Parse(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    Console.Write("Please enter int :");
                    int number = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("{0}",number + 1);
                    break;
                case 2:
                    Console.Write("Please enter double :");
                    double number2 = Double.Parse(Console.ReadLine());
                    Console.WriteLine("{0}", number2 + 1);
                    break;
                case 3:
                    Console.Write("Please enter string :");
                    string text = Console.ReadLine();
                    Console.WriteLine(text + "*");
                    break;
            }
        }
    }