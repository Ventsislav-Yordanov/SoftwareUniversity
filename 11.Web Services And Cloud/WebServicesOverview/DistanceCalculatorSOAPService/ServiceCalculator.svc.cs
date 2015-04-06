using System;

namespace DistanceCalculatorSOAPService
{
    public class ServiceCalculator : ICalculator
    {
        public double CalculateDistance(Point startPoint, Point endPoint)
        {
            var deltaX = startPoint.X - endPoint.X;
            var deltaY = startPoint.Y - endPoint.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
