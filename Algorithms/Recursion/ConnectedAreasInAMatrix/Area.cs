namespace ConnectedAreasInAMatrix
{
    using System;

    public class Area : IComparable<Area>
    {
        public Area(int row, int col, int size)
        {
            this.Row = row;
            this.Col = col;
            this.Size = size;
        }

        public int Col { get; set; }

        public int Row { get; set; }

        public int Size { get; set; }

        public int CompareTo(Area other)
        {
            int result = other.Size.CompareTo(this.Size);
            if (result == 0)
            {
                result = this.Row.CompareTo(other.Row);
            }
            if (result == 0)
            {
                result = this.Col.CompareTo(other.Col);
            }

            return result;
        }
    }
}
