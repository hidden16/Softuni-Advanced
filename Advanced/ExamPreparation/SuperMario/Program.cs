using System;

namespace SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lives = int.Parse(Console.ReadLine());
            var matrixRows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[matrixRows][];
            var marioRow = 0;
            var marioCol = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                    if (matrix[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }
            while (true)
            {
                matrix[marioRow][marioCol] = '-';
                var movement = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var bowserRow = int.Parse(movement[1]);
                var bowserCol = int.Parse(movement[2]);
                matrix[bowserRow][bowserCol] = 'B';
                lives--;
                if (movement[0] == "W")
                {
                    if (IsInRange(matrix, marioRow - 1, marioCol))
                    {
                        marioRow--;
                        if (matrix[marioRow][marioCol] == 'B')
                        {
                            lives -= 2;

                        }
                        else if (matrix[marioRow][marioCol] == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            break;
                        }

                    }
                }
                else if (movement[0] == "S")
                {
                    if (IsInRange(matrix, marioRow + 1, marioCol))
                    {
                        marioRow++;
                        if (matrix[marioRow][marioCol] == 'B')
                        {
                            lives -= 2;

                        }
                        else if (matrix[marioRow][marioCol] == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            break;
                        }
                    }
                }
                else if (movement[0] == "A")
                {
                    if (IsInRange(matrix, marioRow, marioCol - 1))
                    {
                        marioCol--;
                        if (matrix[marioRow][marioCol] == 'B')
                        {
                            lives -= 2;

                        }
                        else if (matrix[marioRow][marioCol] == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            break;
                        }
                    }
                }
                else if (movement[0] == "D")
                {
                    if (IsInRange(matrix, marioRow, marioCol + 1))
                    {
                        marioCol++;
                        if (matrix[marioRow][marioCol] == 'B')
                        {
                            lives -= 2;

                        }
                        else if (matrix[marioRow][marioCol] == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            break;
                        }
                    }
                }

                if (lives <= 0)
                {
                    matrix[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    PrintMatrix(matrix, marioRow, marioCol);
                    return;
                }
            }
            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            PrintMatrix(matrix, marioRow, marioCol);
        }
        public static bool IsInRange(char[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }
        public static void PrintMatrix(char[][] matrix, int row, int col)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
