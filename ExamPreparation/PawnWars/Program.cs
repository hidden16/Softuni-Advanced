using System;
using System.Text;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new char[8, 8];
            var whiteRow = 0;
            var whiteCol = 0;
            var blackRow = 0;
            var blackCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }
            while (true)
            {
                if (IsInRange(matrix, whiteRow - 1, whiteCol + 1) && matrix[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {Coordinates(whiteRow - 1, whiteCol + 1)}.");
                    return;
                }
                else if (IsInRange(matrix, whiteRow - 1, whiteCol - 1) && matrix[whiteRow - 1, whiteCol - 1] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {Coordinates(whiteRow - 1, whiteCol - 1)}.");
                    return;
                }
                else
                {
                    whiteRow--;
                    if (whiteRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {Coordinates(whiteRow, whiteCol)}.");
                        return;
                    }
                }
                if (IsInRange(matrix, blackRow + 1, blackCol + 1) && matrix[blackRow + 1, blackCol + 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {Coordinates(blackRow + 1, blackCol + 1)}.");
                    return;
                }
                else if (IsInRange(matrix, blackRow + 1, blackCol - 1) && matrix[blackRow + 1, blackCol - 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {Coordinates(blackRow + 1, blackCol - 1)}.");
                    return;
                }
                else
                {
                    blackRow++;
                    if (blackRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {Coordinates(blackRow, blackCol)}.");
                        return;
                    }
                }
            }

        }
        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row <= 7 && col >= 0 && col <= 7)
            {
                return true;
            }
            return false;
        }
        public static string Coordinates(int row, int col)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 8; i >= 0; i--)
            {
                if (i == col)
                {
                    sb.Append((char)(i + 97));
                }
            }
            int counter = 8;
            for (int i = 0; i <= 8; i++)
            {
                if (row == i)
                {
                    sb.Append(counter);
                }
                counter--;
            }
            return sb.ToString();
        }
    }
}
