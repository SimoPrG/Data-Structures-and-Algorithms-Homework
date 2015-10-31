namespace Labyrinth
{
    internal class Cell
    {
        public Cell(int row, int col, string symbol)
        {
            this.Row = row;
            this.Col = col;
            this.Symbol = symbol;
        }

        public int Row { get; }

        public int Col { get; }

        public string Symbol { get; }
    }
}