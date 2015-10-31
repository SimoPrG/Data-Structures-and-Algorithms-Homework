//(*) We are given a labyrinth of size N x N.
//  - Some of its cells are empty (`0`) and some are full(`x`).
//  - We can move from an empty cell to another empty cell if they share common wall.
//  - Given a starting position (`*`) calculate and fill in the array the minimal distance
//  - from this position to any other cell in the array. Use "`u`" for all unreachable cells.

namespace Labyrinth
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        public static void Main()
        {
            string[,] labyrinth =
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" }
            };

            PrintLabyrinth(labyrinth);
            Console.WriteLine();
            PrintLabyrinth(SolveLabyrinth(labyrinth));
        }

        public static void PrintLabyrinth(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write($"{labyrinth[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        public static string[,] SolveLabyrinth(string[,] labyrinth)
        {
            var solvedLabyrinth = (string[,])labyrinth.Clone();

            int rows = solvedLabyrinth.GetLength(0);
            int cols = solvedLabyrinth.GetLength(1);

            var startPostitions = GetCells(solvedLabyrinth, "*");
            var cells = new Queue<Cell>(startPostitions);
            while (cells.Count > 0)
            {
                var currentCell = cells.Dequeue();

                int stepNumber;
                string nextSymbol = int.TryParse(currentCell.Symbol, out stepNumber) ? (stepNumber + 1).ToString() : "1";

                if (0 < currentCell.Row && solvedLabyrinth[currentCell.Row - 1, currentCell.Col] == "0")
                {
                    var upCell = new Cell(currentCell.Row - 1, currentCell.Col, nextSymbol);
                    WriteCellInLabyrinth(upCell, solvedLabyrinth);
                    cells.Enqueue(upCell);
                }

                if (currentCell.Row < rows - 1 && solvedLabyrinth[currentCell.Row + 1, currentCell.Col] == "0")
                {
                    var downCell = new Cell(currentCell.Row + 1, currentCell.Col, nextSymbol);
                    WriteCellInLabyrinth(downCell, solvedLabyrinth);
                    cells.Enqueue(downCell);
                }

                if (0 < currentCell.Col && solvedLabyrinth[currentCell.Row, currentCell.Col - 1] == "0")
                {
                    var leftCell = new Cell(currentCell.Row, currentCell.Col - 1, nextSymbol);
                    WriteCellInLabyrinth(leftCell, solvedLabyrinth);
                    cells.Enqueue(leftCell);
                }

                if (currentCell.Col < cols - 1 && solvedLabyrinth[currentCell.Row, currentCell.Col + 1] == "0")
                {
                    var rightCell = new Cell(currentCell.Row, currentCell.Col + 1, nextSymbol);
                    WriteCellInLabyrinth(rightCell, solvedLabyrinth);
                    cells.Enqueue(rightCell);
                }
            }

            var unreachableCells = GetCells(solvedLabyrinth, "0");
            foreach (var cell in unreachableCells)
            {
                solvedLabyrinth[cell.Row, cell.Col] = "u";
            }

            return solvedLabyrinth;
        }

        private static IEnumerable<Cell> GetCells(string[,] labyrinth, string symbol)
        {
            var result = new List<Cell>();
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == symbol)
                    {
                        result.Add(new Cell(row, col, symbol));
                    }
                }
            }

            return result;
        }

        private static void WriteCellInLabyrinth(Cell cell, string[,] labyrinth)
        {
            labyrinth[cell.Row, cell.Col] = cell.Symbol;
        }
    }
}