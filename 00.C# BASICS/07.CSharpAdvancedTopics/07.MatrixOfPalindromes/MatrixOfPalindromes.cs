using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixOfPalindromes
{
    static void Main()
    {
        int matrixRows = Int32.Parse(Console.ReadLine());
        int matrixCols = Int32.Parse(Console.ReadLine());

        string[,] polidromexMatrix = new string[matrixRows, matrixCols];

        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                polidromexMatrix[row, col] = "" + (char)('a' + row) + (char)('a' + row + col) + (char)('a' + row);
            }
        }

        // print elemenets
        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                Console.Write(polidromexMatrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}