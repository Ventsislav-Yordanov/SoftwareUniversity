namespace KnightsTour
{
    public class Cell
    {
        public Cell(int col, int row)
        {
            this.Col = col;
            this.Row = row;
        }

        public int Col { get; set; }

        public int Row { get; set; }
    }
}
