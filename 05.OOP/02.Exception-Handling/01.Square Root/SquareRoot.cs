using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 class SquareRoot
 {
     static void Main(string[] args)
     {
         try
         {
            Console.Write("Enter a number : ");
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            double squareRoot = Math.Sqrt(number);
            Console.WriteLine("Square root from number : {0} is {1}", number, squareRoot);
         }
         catch (ArgumentNullException)
         {
             Console.Error.WriteLine("Invalid Number!");
         }
         catch (OverflowException)
         {
             Console.Error.WriteLine("Too long Number! [ overflow ]");
         }
         catch (FormatException)
         {
             Console.Error.WriteLine("Invalid Number!");
         }
         finally
         {
             Console.WriteLine("Good bye!");
         }
     }
 }