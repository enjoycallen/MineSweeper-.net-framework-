namespace MineSweeper
{
    public class Shape
    {
        public int row { get; set; }
        public int col { get; set; }

        public Shape() { }

        public Shape(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
