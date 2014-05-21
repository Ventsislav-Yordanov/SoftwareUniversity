using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

class PerimeterAndAreaOfPolygon
{
    static double CalculateDistance(int x1, int y1, int x2, int y2)
    {
        int distanceX = x2 - x1;
        int distanceY = y2 - y1;

        double distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));
        return distance;
    }

    static double PolygonPerimeter(Point[] perimeter)
    {
        double peri = 0;
        for (int i = 0; i < perimeter.Length - 1; i++)
        {
            peri += CalculateDistance(perimeter[i].X, perimeter[i].Y,
                                      perimeter[i + 1].X, perimeter[i + 1].Y);
        }
        return peri;
    }

    static double PolygonArea(int[,] matrix, int rows)
    {
        double matrixResult;
        double leftSideSum = 0;
        double rightSideSum = 0;

        for (int i = 0; i < rows - 1; i++)
        {
            leftSideSum += (matrix[i, 0] * matrix[i + 1, 1]);
            rightSideSum += (matrix[i, 1] * matrix[i + 1, 0]);
        }

        matrixResult = Math.Abs((leftSideSum - rightSideSum) / 2);

        return matrixResult;
    }
    static void Main()
    {
        int pointsNumber = int.Parse(Console.ReadLine());
        int[,] matrix = new int[pointsNumber, 2];

        Point[] perimeter = new Point[pointsNumber];

        for (int i = 0; i < pointsNumber; i++)
        {
            string pointCoordinates = Console.ReadLine();
            string[] coordinate = pointCoordinates.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            perimeter[i] = new Point() { X = int.Parse(coordinate[0]), Y = int.Parse(coordinate[1]) };
            matrix[i, 0] = int.Parse(coordinate[0]);
            matrix[i, 1] = int.Parse(coordinate[1]);
        }

        Console.WriteLine("The Perimeter of the polygon is {0:F2}", PolygonPerimeter(perimeter));
        Console.WriteLine("The Area of the polygon is {0:F2}", PolygonArea(matrix, pointsNumber));

    }
}