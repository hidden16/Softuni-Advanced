using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            int[][] matrix = new int[dimensions][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[i] = new int[input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i][j] = input[j];
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
                    if ((row >= 0 && row < matrix.Length) && (col >= 0 && col < matrix[row].Length))
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid coordinates");
                    }
                }
                if (tokens[0] == "Subtract")
                {
                    var row = int.Parse(tokens[1]);
                    var col = int.Parse(tokens[2]);
                    var value = int.Parse(tokens[3]);
                    if ((row >= 0 && row < matrix.Length) && (col >= 0 && col < matrix[row].Length))
                    {
                        matrix[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid coordinates");
                    }
                }
                commands = Console.ReadLine();
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
