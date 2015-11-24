namespace ShortestPathInMatrix
{
    using System;
    using System.Collections.Generic;

    public class Cell : IComparable
    {
        public Cell(int row, int column, int value, int initialValue)
        {
            this.Column = column;
            this.Row = row;
            this.Value = value;
            this.InitialValue = initialValue;
            this.IsVisited = false;
            this.Neighbours = new List<Cell>();
        }

        public int Column { get; set; }

        public int Row { get; set; }

        public int InitialValue { get; set; }

        public int Value { get; set; }

        public bool IsVisited { get; set; }

        public Cell Prevous { get; set; }

        public List<Cell> Neighbours { get; set; }

        public int CompareTo(object obj)
        {
            var other = (obj as Cell);
            return this.Value.CompareTo(other.Value);
        }
    }
}
