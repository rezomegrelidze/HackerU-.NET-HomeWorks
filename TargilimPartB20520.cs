using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Targil2.Run();
        }

        #region Problems Part B

        #region Targil1

        public static int Measure(int[] a, int[] b)
        {
            return a.Sum().CompareTo(b.Sum());
        }

        #endregion

        #region Targil2


        public static class Targil2
        {
            public static void Run()
            {
                // This board matrix describes the following board
                //   O | O | X
                //   O | X | O
                //   X | O | O
                //
                var matrix = new int[,]
                {
                    {0,0,1},
                    {0,1,0},
                    {1,0,0},
                };

                int result = WinX0(matrix);

                switch (result)
                {
                    case -1:
                        Console.WriteLine("Matrix size is illegal");
                        break;
                    case -2:
                        Console.WriteLine("Matrix is not full with 0s and 1s");
                        break;
                    case 1:
                        Console.WriteLine("X is the winner");
                        break;
                    case 2:
                        Console.WriteLine("Y is the winner");
                        break;
                    default:
                        Console.WriteLine("It's a draw");
                        break;
                }
            }

            public static int WinX0(int[,] board)
            {
                // 3x3 matrix where 1:X, 0:O,

                if (board.GetLength(0) != 3 || board.GetLength(1) != 3) return -1;
                if (!board.Cast<int>().Any(x => x >= 0 && x <= 1)) return -2;

                return CheckForWinner(board);
            }

            private static int CheckForWinner(int[,] board)
            {
                var allRows = GetAllRows(board);
                var allColumns = GetAllColumns(board);
                var diagonals = GetAllDiagonals(board);

                var Xsequence = new[] { 1, 1, 1 };
                var Osequence = new[] { 0, 0, 0 };

                var allPossibleLines = Enumerable.Concat<IEnumerable<int>>(allRows, allColumns).Concat(diagonals);
                if (allPossibleLines.Any(line => line.SequenceEqual(Xsequence))) return 1;
                else if (allPossibleLines.Any(line => line.SequenceEqual(Osequence))) return 2;
                else return 0;
            }

            private static IEnumerable<IEnumerable<int>> GetAllDiagonals(int[,] board)
            {
                return new[]
                {
                    new[] {board[0, 0], board[1, 1], board[2, 2]},
                    new[] {board[2, 0], board[1, 1], board[0, 2]}
                };
            }

            private static IEnumerable<IEnumerable<int>> GetAllColumns(int[,] board)
            {
                for (int col = 0; col < 3; col++)
                {
                    yield return Enumerable.Range(0, 3).Select(row => board[row, col]);
                }
            }

            private static IEnumerable<IEnumerable<int>> GetAllRows(int[,] board)
            {
                for (int row = 0; row < 3; row++)
                {
                    yield return Enumerable.Range(0, 3).Select(col => board[row, col]);
                }
            }
        }

        #endregion


        #endregion
    }
}
