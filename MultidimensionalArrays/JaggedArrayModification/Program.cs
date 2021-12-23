using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            int[,] matrix = new int[dimensions, dimensions];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            var commands = Console.ReadLine();
            while (commands != "END")
            {
                var tokens = commands.Split();
                if (tokens[0] == "Add")
                {
                    var row = int.Parse(tokens[1]);
                    var col = int.Parse(tokens[2]);
                    var value = int.Parse(tokens[3]);
                    if ((row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1)))
                    {
                        matrix[row, col] += value;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid coordinates");
                    }
                }
                else if (tokens[0] == "Subtract")
                {
                    var row = int.Parse(tokens[1]);
                    var col = int.Parse(tokens[2]);
                    var value = int.Parse(tokens[3]);
                    if ((row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1)))
                    {
                        matrix[row, col] -= value;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid coordinates");
                    }
                }

                commands = Console.ReadLine();
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
