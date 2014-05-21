/*Classical play cards use the following signs to designate 
 * the card face: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A.
 * Write a program that enters a string and prints “yes” if it is a valid card sign
 * or “no” otherwise. */
using System;

    class CheckForAPlayCard
    {
        static void Main()
        {
            Console.Write("character : ");
            string character = Console.ReadLine();

            switch (character)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "A":
                case "J":
                case "K":
                case "Q": Console.WriteLine("Valid card sign?  - yes");
                    break;
                default: Console.WriteLine("Valid card sign?  - no");
                    break;
            }
        }
    }