using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[matrixInput[0], matrixInput[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
            while (true)
            {
                var commands = Console.ReadLine();
                if (commands == "Bloom Bloom Plow")
                {
                    break;
                }
                var movements = commands.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var row = movements[0];
                var col = movements[1];
                if (!IsInRange(matrix,row,col))
                {
                    Console.WriteLine($"Invalid coordinates.");
                    continue;
                }
                matrix[row, col]++;
                // up --
                for (int i = row - 1; i >= 0; i--)
                {
                    matrix[i, col]++;
                }
                // down ++
                for (int i = row + 1; i < matrix.GetLength(0); i++)
                {
                    matrix[i, col]++;
                }
                // left --
                for (int i = col - 1; i >= 0; i--)
                {
                    matrix[row, i]++;
                }
                // right ++
                for (int i = col + 1; i < matrix.GetLength(1); i++)
                {
                    matrix[row, i]++;
                }
            }
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
        public static bool IsInRange(int[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col< matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
