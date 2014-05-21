/*Declare a Boolean variable called isFemale and assign an appropriate value corresponding to your gender.
 * Print it on the console.*/
using System;

    class BooleanVariable
    {
        static void Main()
        {
            Console.Write("Enter your gender ( female OR male ) : ");
            string gender = Console.ReadLine();
            bool isFemale = true;

            if (gender == "male")
            {
                isFemale = false;
            }
            Console.WriteLine("Am I Female ? answer : {0}",isFemale);
        }
    }
