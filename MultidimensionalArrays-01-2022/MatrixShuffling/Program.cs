using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new string[dimensions[0], dimensions[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            var cmds = Console.ReadLine();
            while (cmds != "END")
            {
                var tokens = cmds.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "swap" && tokens.Length == 5)
                {
                    var row1 = int.Parse(tokens[1]);
                    var col1 = int.Parse(tokens[2]);
                    var row2 = int.Parse(tokens[3]);
                    var col2 = int.Parse(tokens[4]);
                    if (row1 >= 0 && row1 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1) && row2 >= 0 && row2 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1))
                    {
                        var rowSaver = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = rowSaver;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                cmds = Console.ReadLine();
            }
        }
    }
}
