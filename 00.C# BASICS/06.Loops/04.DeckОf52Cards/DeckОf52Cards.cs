/*Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers).
 * The cards should be printed using the classical notation (like 5♠, A♥, 9♣ and K♦).
 * The card faces should start from 2 to A. Print each card face in its four possible suits:
 * clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement.*/
using System;

    class DeckОf52Cards
    {
        static void Main()
        {
            int a = 3;
            int b = 4;
            int c = 5;
            int d = 6;

            for (int i = 2; i < 15; i++)
            {
                if (i > 1 && i < 11)
                {
                    Console.WriteLine("{0}{1} {0}{2} {0}{3} {0}{4}", i, (char)a, (char)b, (char)c, (char)d);

                }
                else
                {
                    for (int j = i; j < i + 1; j++)
                        switch (i)
                        {
                            case 11:
                                Console.WriteLine("D{0} D{1} D{2} D{3}", (char)a, (char)b, (char)c, (char)d);
                                break;
                            case 12:
                                Console.WriteLine("A{0} A{1} A{2} A{3}", (char)a, (char)b, (char)c, (char)d);
                                break;
                            case 13:
                                Console.WriteLine("J{0} J{1} J{2} J{3}", (char)a, (char)b, (char)c, (char)d);
                                break;
                            case 14:
                                Console.WriteLine("K{0} K{1} K{2} K{3}", (char)a, (char)b, (char)c, (char)d);
                                break;
                        }
                }
            }
        }
    }