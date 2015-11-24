namespace RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RectangleIntersectionExample
    {
        public static void Main()
        {
            int numberOfRectangles = int.Parse(Console.ReadLine());
            var allRectangles = new Rectangle[numberOfRectangles];
            var xCoordinates = new List<int>();
            var yCoordinates = new List<int>();
            for (int i = 0; i < numberOfRectangles; i++)
            {
                var currentRectangleCordinates = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int minX = currentRectangleCordinates[0];
                int maxX = currentRectangleCordinates[1];
                int minY = currentRectangleCordinates[2];
                int maxY = currentRectangleCordinates[3];
                var rectangle = new Rectangle(minX, maxX, minY, maxY);
                allRectangles[i] = rectangle;
                xCoordinates.Add(minX);
                xCoordinates.Add(maxX);
                yCoordinates.Add(minY);
                yCoordinates.Add(maxY);
            }

            xCoordinates.Sort();
            yCoordinates.Sort();

            int xIntervalsCount = xCoordinates.Count - 1;
            var rectanglesInXIntervals = new List<Rectangle>[xIntervalsCount];
            for (int i = 0; i < rectanglesInXIntervals.Length; i++)
            {
                rectanglesInXIntervals[i] = new List<Rectangle>();
            }

            foreach (var rectangle in allRectangles)
            {
                for (int xInterval = 0; xInterval < xIntervalsCount; xInterval++)
                {
                    if (rectangle.MaxX > xCoordinates[xInterval] && rectangle.MinX < xCoordinates[xInterval + 1])
                    {
                        rectanglesInXIntervals[xInterval].Add(rectangle);
                    }
                }
            }

            int totalArea = 0;
            for (int xIntervalIndex = 0; xIntervalIndex < xIntervalsCount; xIntervalIndex++)
            {
                int yIntervalsCount = yCoordinates.Count - 1;
                var overlaps = new int[yIntervalsCount];
                foreach (var rectangle in rectanglesInXIntervals[xIntervalIndex])
                {
                    for (int yInterval = 0; yInterval < yIntervalsCount; yInterval++)
                    {
                        if (rectangle.MaxY > yCoordinates[yInterval] && rectangle.MinY < yCoordinates[yInterval + 1])
                        {
                            overlaps[yInterval]++;
                        }
                    }
                }

                for (int yIntervalIndex = 0; yIntervalIndex < overlaps.Length; yIntervalIndex++)
                {
                    if (overlaps[yIntervalIndex] >= 2)
                    {
                        int deltaX = xCoordinates[xIntervalIndex + 1] - xCoordinates[xIntervalIndex];
                        int deltaY = yCoordinates[yIntervalIndex + 1] - yCoordinates[yIntervalIndex];
                        int currentArea = deltaX * deltaY;
                        totalArea += currentArea;
                    }
                }
            }

            Console.WriteLine(totalArea);
        }
    }
}
