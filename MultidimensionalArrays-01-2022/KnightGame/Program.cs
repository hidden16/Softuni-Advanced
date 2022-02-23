using System;
using System.Linq;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = int.Parse(Console.ReadLine());
            var matrix = new char[dimensions, dimensions];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            var counter = 0;
            while (true)
            {
                var maxAttack = int.MinValue;
                var maxRow = 0;
                var maxCol = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == '0')
                        {
                            continue;
                        }
                        var currentAttacks = 0;
                        if (IsInRange(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix, row - 1,col - 2) && matrix[row - 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix,row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix,row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix,row + 1,col - 2) && matrix[row + 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix,row + 2,col - 1) && matrix[row + 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInRange(matrix, row + 1,col + 2) && matrix[row + 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (currentAttacks > maxAttack)
                        {
                            maxAttack = currentAttacks;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }
                if (maxAttack > 0)
                {
                    matrix[maxRow, maxCol] = '0';
                    counter++;
                }
                else
                {
                    Console.WriteLine(counter);
                    return;
                }
            }
        }

        private static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
