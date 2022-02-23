using System;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var currRow = 0;
            var currCol = 0;
            int[] mirrorOne = new int[2];
            int[] mirrorTwo = new int[2];
            bool mirrorTwoFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'A')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    else if (matrix[row, col] == 'M')
                    {
                        if (mirrorTwoFound == false)
                        {
                            mirrorOne[0] = row;
                            mirrorOne[1] = col;
                            mirrorTwoFound = true;
                        }
                        else if (mirrorTwoFound == true)
                        {
                            mirrorTwo[0] = row;
                            mirrorTwo[1] = col;
                        }
                    }
                }
            }
            matrix[currRow, currCol] = '-';
            bool isOut = false;
            var sum = 0;
            var neededSum = false;
            while (true)
            {
                var movements = Console.ReadLine();
                if (movements == "up" && IsInRange(matrix, currRow - 1, currCol))
                {
                    currRow--;
                    if (char.IsDigit(matrix[currRow,currCol]))
                    {
                        sum += (int)Char.GetNumericValue(matrix[currRow,currCol]);
                        matrix[currRow, currCol] = '-';
                    }
                    else if (matrix[currRow,currCol] == 'M')
                    {
                        matrix[currRow, currCol] = '-';
                        currRow = mirrorTwo[0];
                        currCol = mirrorTwo[1];
                        matrix[currRow, currCol] = '-';
                    }
                }
                else if (movements == "down" && IsInRange(matrix, currRow + 1, currCol))
                {
                    currRow++;
                    if (char.IsDigit(matrix[currRow, currCol]))
                    {
                        sum += (int)Char.GetNumericValue(matrix[currRow, currCol]);
                        matrix[currRow, currCol] = '-';
                    }
                    else if (matrix[currRow, currCol] == 'M')
                    {
                        matrix[currRow, currCol] = '-';
                        currRow = mirrorTwo[0];
                        currCol = mirrorTwo[1];
                        matrix[currRow, currCol] = '-';
                    }
                }
                else if (movements == "left" && IsInRange(matrix, currRow, currCol - 1))
                {
                    currCol--;
                    if (char.IsDigit(matrix[currRow, currCol]))
                    {
                        sum += (int)Char.GetNumericValue(matrix[currRow, currCol]);
                        matrix[currRow, currCol] = '-';
                    }
                    else if (matrix[currRow, currCol] == 'M')
                    {
                        matrix[currRow, currCol] = '-';
                        currRow = mirrorTwo[0];
                        currCol = mirrorTwo[1];
                        matrix[currRow, currCol] = '-';
                    }
                }
                else if (movements == "right" && IsInRange(matrix, currRow, currCol + 1))
                {
                    currCol++;
                    if (char.IsDigit(matrix[currRow, currCol]))
                    {
                        sum += (int)Char.GetNumericValue(matrix[currRow, currCol]);
                        matrix[currRow, currCol] = '-';
                    }
                    else if (matrix[currRow, currCol] == 'M')
                    {
                        matrix[currRow, currCol] = '-';
                        currRow = mirrorTwo[0];
                        currCol = mirrorTwo[1];
                        matrix[currRow, currCol] = '-';
                    }
                }
                else
                {
                    matrix[currRow,currCol] = '-';
                    isOut = true;
                    break;
                }
                if (sum >= 65)
                {
                    matrix[currRow, currCol] = 'A';
                    neededSum = true;
                    break;
                }
            }
            if (isOut)
            {
                Console.WriteLine($"I do not need more swords!");
            }
            if (neededSum)
            {
                Console.WriteLine($"Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {sum} gold coins.");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}