using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MemoryGame
{
    class Program
    {
        private static int RowCount;
        private static int ColumnCount;
        static void Main(string[] args)
        {
            ReceiveBoardDimensionsFromUser();

            int initialValuesSize = RowCount * ColumnCount / 2;

            // The code implementor should choose which initial values to use for memory game initialization
            // I use integers in this example. You can use any type that has a meaningful ToString overload. 
            var initialValuesForMemoryGame = Enumerable.Range(1, initialValuesSize);
            StartMemoryGame(initialValuesForMemoryGame);
        }

        private static void ReceiveBoardDimensionsFromUser()
        {
            (string row, string col) rowColInput;
            do
            {
                string input;
                do
                {
                    Console.WriteLine("Please input memory game dimensions: [rows,cols]");
                    input = Console.ReadLine();
                } while (!(Regex.IsMatch(input, "[0-9]+,[0-9]+")));


                rowColInput = (input.Split(",")[0], input.Split(",")[1]);
            } while (!int.TryParse(rowColInput.row, out RowCount) & 
                     !int.TryParse(rowColInput.col, out ColumnCount));

            if (RowCount * ColumnCount % 2 != 0)
            {
                // If the product of the final validated row,col pair is not even then recieve and validate input again
                ReceiveBoardDimensionsFromUser();
            }
        }

        private static void StartMemoryGame<T>(IEnumerable<T> initialValues)
        {
            var memoryMatrix = new T[RowCount, ColumnCount];
            var guessed = GenerateGuessDictionary(initialValues);


            FillMatrixWithInitialValues(memoryMatrix, initialValues);
            ShuffleMatrix(memoryMatrix);

            DrawMemoryGame(memoryMatrix, guessed);

            (int row, int col) prevPosGuessed = (-1, -1);

            do
            {
                (int, int) inputPosition;
                do
                {
                    Console.WriteLine("Please enter position of card to open (example: 1,1): ");
                } while (!TryParsePosition(Console.ReadLine(), out inputPosition));

                if (prevPosGuessed != (-1, -1) &&
                    GetValueFromPosition(memoryMatrix, prevPosGuessed).Equals(GetValueFromPosition(memoryMatrix, inputPosition)))
                {
                    guessed[memoryMatrix[prevPosGuessed.row, prevPosGuessed.col]] = true;
                }

                Console.Clear();
                DrawMemoryGame(memoryMatrix, guessed, inputPosition);
                prevPosGuessed = inputPosition;
            } while (!BoardFull(guessed,initialValues));

            Console.WriteLine("End of game. Have a nice day!!");
        }

        private static Dictionary<T, bool> GenerateGuessDictionary<T>(IEnumerable<T> initialValues)
            => initialValues.Zip(Enumerable.Repeat(false, initialValues.Count()), ((key, value) => (key, value)))
                .ToDictionary(t => t.key, t => t.value);

        private static bool BoardFull<T>(Dictionary<T,bool> guessed,IEnumerable<T> allValues) 
            => allValues.All(value => guessed[value]);

        private static T GetValueFromPosition<T>(T[,] matrix, (int row, int col) position) => matrix[position.row, position.col];

        private static bool TryParsePosition(string input, out (int row, int col) result)
        {
            if (!Regex.IsMatch(input, "[0-9]+,[0-9]+"))
            {
                result = (-1, -1);
                return false;
            }

            var split = input.Split(',');
            result = (int.Parse(split[0]) - 1, int.Parse(split[1]) - 1); // return -1 because matricies use indexing from zero
            return result.row >= 0 && result.row < RowCount && result.col >= 0 && result.col < ColumnCount;
        }

        private static void DrawMemoryGame<T>(T[,] memoryMatrix, Dictionary<T,bool> guessed, (int, int)? position = null)
        {
            for (int row = 0; row < RowCount; row++)
            {
                for (int col = 0; col < ColumnCount; col++)
                {
                    if (guessed[memoryMatrix[row, col]] || position != null && position == (row, col))
                    {
                        Console.Write($"{{{memoryMatrix[row, col]}}}\t");
                    }
                    else
                    {
                        Console.Write("{ }\t");
                    }
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrixWithInitialValues<T>(T[,] memoryMatrix,IEnumerable<T> initialValues) => 
            FillMatrixWithValues(memoryMatrix, initialValues.SelectMany(x => new[] { x, x }));

        private static void ShuffleMatrix<T>(T[,] memoryMatrix)
        {
            var values = memoryMatrix.Cast<T>().ToArray();
            Random rand = new Random();
            for (int i = 0; i < values.Length; i++)
            {
                int j = rand.Next(i);
                Swap(values, i, j);
            }

            FillMatrixWithValues(memoryMatrix, values);
        }

        private static void Swap<T>(T[] array, int i, int j) 
            => (array[i], array[j]) = (array[j], array[i]);


        private static void FillMatrixWithValues<T>(T[,] memoryMatrix, IEnumerable<T> values)
        {

            var allValues = new Queue<T>(values);

            for (int row = 0; row < memoryMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < memoryMatrix.GetLength(1); col++)
                {
                    memoryMatrix[row, col] = allValues.Dequeue();
                }
            }
        }
    }
}
