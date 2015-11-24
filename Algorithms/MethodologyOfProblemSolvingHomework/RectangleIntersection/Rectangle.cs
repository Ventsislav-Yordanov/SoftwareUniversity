namespace RectangleIntersection
{
    using System;

    public class Rectangle : IComparable<Rectangle>
    {
        public Rectangle(int minX, int maxX, int minY, int maxY)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
        }

        public int MinX { get; set; }

        public int MaxX { get; set; }

        public int MinY { get; set; }

        public int MaxY { get; set; }

        public int CompareTo(Rectangle other)
        {
            return this.MinY.CompareTo(other.MinY);
        }
    }
}
