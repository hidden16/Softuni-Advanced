using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[dimensions[0], dimensions[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            var maxSum = int.MinValue;
            var total = 0;
            var maxRow = 0;
            var maxCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var sumOne = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    var sumTwo = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    var sumThree = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    total = sumOne + sumTwo + sumThree;
                    if (total > maxSum)
                    {
                        maxSum = total;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxRow; row <= maxRow + 2; row++)
            {
                for (int col = maxCol; col <= maxCol + 2; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
