using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class KaspichaniaBoats
    {
        static void Main()
        {
            int n = Int32.Parse(Console.ReadLine());

            int width = n * 2 + 1;
            int height = 6 + ((n - 3) / 2) * 3;

            int dotsBeforeAndAfter = n;
            int stars = 1;

            Console.Write(new string('.', dotsBeforeAndAfter));
            Console.Write(new string('*', stars));
            Console.Write(new string('.', dotsBeforeAndAfter));
            Console.WriteLine();

            int dotsBetween = 0;
            dotsBeforeAndAfter--;

            do
            {
                Console.Write(new string('.', dotsBeforeAndAfter));
                Console.Write(new string('*', stars));
                Console.Write(new string('.', dotsBetween));
                Console.Write(new string('*', stars));
                Console.Write(new string('.', dotsBetween));
                Console.Write(new string('*', stars));
                Console.Write(new string('.', dotsBeforeAndAfter));
                Console.WriteLine();
                dotsBetween++;
                dotsBeforeAndAfter--;
            } while (dotsBeforeAndAfter > 0);


            Console.WriteLine(new string('*', width));

            while (dotsBeforeAndAfter != dotsBetween)
            {
                dotsBetween --;
                dotsBeforeAndAfter++;
                Console.Write(new string('.', dotsBeforeAndAfter));
                Console.Write(new string('*', stars));
                Console.Write(new string('.', dotsBetween));
                Console.Write(new string('*', stars));
                Console.Write(new string('.', dotsBetween));
                Console.Write(new string('*', stars));
                Console.Write(new string('.', dotsBeforeAndAfter));
                Console.WriteLine();
            }

            // print final row
            int finalStars = n;
            int finalDots = (width - finalStars) / 2;

            Console.Write(new string('.', finalDots));
            Console.Write(new string('*', finalStars));
            Console.Write(new string('.', finalDots));
        }
    }