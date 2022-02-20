using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var beaverRow = 0;
            var beaverCol = 0;
            var branchesCount = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    if (char.IsLower(matrix[row, col]))
                    {
                        branchesCount++;
                    }
                }
            }
            List<char> branchesCollected = new List<char>();
            while (true)
            {
                var movements = Console.ReadLine();
                if (movements == "end")
                {
                    break;
                }
                if (movements == "up" && IsInRange(matrix, beaverRow - 1, beaverCol))
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverRow--;
                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        branchesCollected.Add(matrix[beaverRow, beaverCol]);
                        branchesCount--;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        if (beaverRow == 0)
                        {
                            beaverRow = matrix.GetLength(0) - 1;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else if (beaverRow != 0)
                        {
                            beaverRow = 0;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (movements == "down" && IsInRange(matrix, beaverRow + 1, beaverCol))
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverRow++;
                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        branchesCollected.Add(matrix[beaverRow, beaverCol]);
                        branchesCount--;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        if (beaverRow == matrix.GetLength(0) - 1)
                        {
                            beaverRow = 0;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else if (beaverRow != matrix.GetLength(0) - 1)
                        {
                            beaverRow = matrix.GetLength(0) - 1;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (movements == "left" && IsInRange(matrix, beaverRow, beaverCol - 1))
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverCol--;
                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        branchesCollected.Add(matrix[beaverRow, beaverCol]);
                        branchesCount--;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        if (beaverCol == 0)
                        {
                            beaverCol = matrix.GetLength(1) - 1;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else if (beaverCol != 0)
                        {
                            beaverCol = 0;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (movements == "right" && IsInRange(matrix, beaverRow, beaverCol + 1))
                {
                    matrix[beaverRow, beaverCol] = '-';
                    beaverCol++;
                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        branchesCollected.Add(matrix[beaverRow, beaverCol]);
                        branchesCount--;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else if (matrix[beaverRow,beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        if (beaverCol == matrix.GetLength(1) - 1)
                        {
                            beaverCol = 0;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else if (beaverCol != matrix.GetLength(1) - 1)
                        {
                            beaverCol = matrix.GetLength(1) - 1;
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else
                {
                    if (branchesCollected.Count > 0)
                    {
                        branchesCollected.RemoveAt(branchesCollected.Count - 1);
                    }
                }
                if (branchesCount == 0)
                {
                    break;
                }
            }
            if (branchesCount == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branchesCollected.Count} wood branches: {string.Join(", ",branchesCollected)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount} branches left.");
            }
            PrintMatrix(matrix);
        }

        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

