using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[][] matrix = new long[n][];
            for (long row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new long[row + 1];
            }
            for (long row = 0; row < matrix.Length; row++)
            {
                matrix[row][0] = 1;
            }
            for (long row = 1; row < matrix.Length; row++)
            {
                for (long col = 1; col < matrix[row].Length; col++)
                {
                    if (col > matrix[row-1].Length - 1)
                    {
                        matrix[row][col] = matrix[row - 1][col - 1];
                    }
                    else
                    {
                        matrix[row][col] = matrix[row - 1][col] + matrix[row - 1][col - 1];
                    }
                }
            }
            for (long row = 0; row < matrix.Length; row++)
            {
                for (long col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
