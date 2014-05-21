using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class IsoscelesTriangle
{
    static void Main(string[] args)
    {
        //This program is changed a bit. It allows the user to choose the height of the triangle.
        //For output with exactly 9 symbols - as it is in the task, you can enter 4 for height.
        //The code is devided in three logical parts - first one prints the edge, the second one
        //shows the lines between the edge and the base and the last one displays the base of the triangle. 
        try
        {
            Console.OutputEncoding = Encoding.UTF8; // This code allows correct output for symbols
            char symbol = '\x00A9';
            byte triangleHeight;
            //The following loop guarantees minimal height because it has to be at least 3
            do
            {
                Console.Write("Enter height of the triangle: ");
                triangleHeight = byte.Parse(Console.ReadLine());
            } while (triangleHeight <= 2);

            int numberSymbolsBase = triangleHeight; // This is the number of symbols for the base without spaces

            if (triangleHeight * 2 > Console.BufferWidth || triangleHeight > Console.BufferHeight)
            {
                Console.SetBufferSize(2 * triangleHeight, triangleHeight + 5);
                //This code sets the size of the buffer according to the dimensions of the triangle,
                //but only if needed
            }

            // Edge of the triangle
            string spacesBeforeEdge = new string(' ', triangleHeight - 1);
            string edge = spacesBeforeEdge + symbol;
            Console.WriteLine(edge);

            // Lines Between the edge and the base of the triangle
            int spacesBetweenCount = 1; // This variable is used for the speces in the triangle
            int spacesBeforeCount = triangleHeight - 2; //Spaces before each line of symbols
            for (int i = 1; i <= triangleHeight - 2; i++)
            {
                string spacesBefore = new string(' ', spacesBeforeCount);
                spacesBeforeCount--;
                string spacesBetween = new string(' ', spacesBetweenCount);
                spacesBetweenCount = spacesBetweenCount + 2;
                string currentLine = spacesBefore + symbol + spacesBetween + symbol;
                Console.WriteLine(currentLine);
            }

            // Base of the triangle
            for (int i = 1; i <= numberSymbolsBase; i++)
            {
                Console.Write(symbol + " ");
            }
            Console.WriteLine();
        }
        catch (FormatException)
        {

            Console.WriteLine("Wrong format for height."); ;
        }
        catch (OverflowException)
        {
            Console.WriteLine("You have entered too big or negative number for height.");
        }
    }
}
