using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            double[][] matrix = new double[dimensions][];
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = new double[input.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else if(matrix[row].Length != matrix[row+1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }
                    for (int col2 = 0; col2 < matrix[row+1].Length; col2++)
                    {
                        matrix[row + 1][col2] /= 2;
                    }
                }
            }
            var commands = Console.ReadLine();
            while (commands != "End")
            {
                var tokens = commands.Split();
                if (tokens[0] == "Add")
                {
                    var row = int.Parse(tokens[1]);
                    var col = int.Parse(tokens[2]);
                    var value = int.Parse(tokens[3]);
                    if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] += value;
                    }
                }
                else if (tokens[0] == "Subtract")
                {
                    var row = int.Parse(tokens[1]);
                    var col = int.Parse(tokens[2]);
                    var value = int.Parse(tokens[3]);
                    if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= value;
                    }
                }
                commands = Console.ReadLine();
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
