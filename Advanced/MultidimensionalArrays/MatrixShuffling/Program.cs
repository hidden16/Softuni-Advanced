using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            var commands = Console.ReadLine();
            string holder = string.Empty;
            while (commands != "END")
            {
                var tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 5 && tokens[0] == "swap")
                {
                    var row1 = int.Parse(tokens[1]);
                    var col1 = int.Parse(tokens[2]);
                    var row2 = int.Parse(tokens[3]);
                    var col2 = int.Parse(tokens[4]);
                    if ((row1 >= 0 && row1 < matrix.GetLength(0)) && (col1 >= 0 && col1 < matrix.GetLength(1)) && (row2 >= 0 && row2 < matrix.GetLength(0)) && (col2 >= 0 && col2 < matrix.GetLength(1)))
                    {
                        holder = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = holder;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                }
                commands = Console.ReadLine();
            }

        }
    }
}
