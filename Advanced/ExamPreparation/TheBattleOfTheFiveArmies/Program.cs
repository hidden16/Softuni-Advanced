using System;
using System.Linq;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            var currRow = 0;
            var currCol = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                    if (matrix[row][col] == 'A')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            Movement(matrix, currRow, currCol, armor);
        }
        public static void Movement(char[][] matrix, int row, int col, int armor)
        {
            while (true)
            {
                var movements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var orcRow = int.Parse(movements[1]);
                var orcCol = int.Parse(movements[2]);
                matrix[orcRow][orcCol] = 'O';
                if (InMatrixCheck(matrix, row, col, movements[0]) == true)
                {
                    armor--;
                    matrix[row][col] = '-';
                    switch (movements[0])
                    {
                        case "up":
                            row--;
                            break;
                        case "down":
                            row++;
                            break;
                        case "left":
                            col--;
                            break;
                        case "right":
                            col++;
                            break;
                        default:
                            break;
                    }
                    if (HitsCharM(matrix, row, col))
                    {
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        matrix[row][col] = '-';
                        PrintMatrix(matrix);
                        return;
                    }
                    if (HitsCharO(matrix, row, col))
                    {
                        armor -= 2;
                    }
                    if (armor <= 0)
                    {
                        Console.WriteLine($"The army was defeated at {row};{col}.");
                        matrix[row][col] = 'X';
                        PrintMatrix(matrix);
                        return;
                    }
                    matrix[row][col] = 'A';
                }
                else
                {
                    armor--;
                    if (armor <= 0)
                    {
                        Console.WriteLine($"The army was defeated at {row};{col}.");
                        matrix[row][col] = 'X';
                        PrintMatrix(matrix);
                        return;
                    }
                    continue;
                }

            }
        }
        public static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
                }
                Console.WriteLine();
            }
        }
        public static bool InMatrixCheck(char[][] matrix, int row, int col, string movement)
        {
            if (movement == "up" && row - 1 >= 0 && row - 1 < matrix.Length)
            {
                return true;
            }
            else if (movement == "down" && row + 1 >= 0 && row + 1 < matrix.Length)
            {
                return true;
            }
            else if (movement == "left" && col - 1 >= 0 && col - 1 < matrix[row].Length)
            {
                return true;
            }
            else if (movement == "right" && col + 1 >= 0 && col + 1 < matrix[row].Length)
            {
                return true;
            }

            return false;
        }
        public static bool HitsCharM(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'M')
            {
                return true;
            }
            return false;
        }
        public static bool HitsCharO(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'O')
            {
                return true;
            }
            return false;
        }

    }
}
