using System;

namespace Survivor
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[][] matrix = new string[n][];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var input = Console.ReadLine().Split(" ");
                matrix[rows] = new string[input.Length];
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    matrix[rows][cols] = input[cols];
                }
            }
            var allyTokens = 0;
            var enemyTokens = 0;
            var row = 0;
            var col = 0;
            var commands = Console.ReadLine();
            while (commands != "Gong")
            {
                var tokens = commands.Split(" ");
                row = int.Parse(tokens[1]);
                col = int.Parse(tokens[2]);
                if (tokens[0] == "Find")
                {
                    if (IsInRange(matrix, row, col))
                    {
                        if (matrix[row][col] == "T")
                        {
                            allyTokens++;
                            matrix[row][col] = "-";
                        }
                    }
                }
                else if (tokens[0] == "Opponent")
                {
                    var direction = tokens[3];
                    if (IsInRange(matrix, row, col))
                    {
                        if (matrix[row][col] == "T")
                        {
                            enemyTokens++;
                            matrix[row][col] = "-";
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            if (direction == "up" && IsInRange(matrix, row - 1, col))
                            {
                                row--;
                                if (matrix[row][col] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row][col] = "-";
                                }
                            }
                            else if (direction == "down" && IsInRange(matrix, row + 1, col))
                            {
                                row++;
                                if (matrix[row][col] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row][col] = "-";
                                }
                            }
                            else if (direction == "left" && IsInRange(matrix, row, col - 1))
                            {
                                col--;
                                if (matrix[row][col] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row][col] = "-";
                                }
                            }
                            else if (direction == "right" && IsInRange(matrix, row, col + 1))
                            {
                                col++;
                                if (matrix[row][col] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row][col] = "-";
                                }
                            }
                        }
                    }
                }
                commands = Console.ReadLine();
            }
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    Console.Write(matrix[rows][cols] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Collected tokens: {allyTokens}");
            Console.WriteLine($"Opponent's tokens: {enemyTokens}");
        }
        public static bool IsInRange(string[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
