using System;

namespace Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            var curRow = 0;
            var curCol = 0;
            int[] pillarOne = new int[2];
            int[] pillarTwo = new int[2];
            bool pillarTwoFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        curRow = row;
                        curCol = col;
                    }
                    else if (matrix[row, col] == 'O')
                    {
                        if (pillarTwoFound == false)
                        {
                            pillarOne[0] = row;
                            pillarOne[1] = col;
                            pillarTwoFound = true;
                        }
                        if (pillarTwoFound == true)
                        {
                            pillarTwo[0] = row;
                            pillarTwo[1] = col;
                        }
                    }
                }
            }
            int money = 0;
            matrix[curRow, curCol] = '-';
            while (true)
            {
                var movements = Console.ReadLine();
                if (movements == "up" && IsInRange(matrix,curRow - 1,curCol))
                {
                    curRow--;
                    if (char.IsDigit(matrix[curRow,curCol]))
                    {
                        money += (int)Char.GetNumericValue(matrix[curRow, curCol]);
                        matrix[curRow, curCol] = '-';
                    }
                    else if (matrix[curRow,curCol] == 'O')
                    {
                        if (matrix[curRow,curCol] == matrix[pillarOne[0], pillarOne[1]])
                        {
                            curRow = pillarTwo[0];
                            curCol = pillarTwo[1];
                            matrix[curRow, curCol] = '-';
                        }
                        else if (matrix[curRow, curCol] == matrix[pillarTwo[0], pillarTwo[1]])
                        {
                            curRow = pillarOne[0];
                            curCol = pillarOne[1];
                            matrix[curRow, curCol] = '-';
                        }
                    }
                }
                else if (movements == "down" && IsInRange(matrix,curRow + 1, curCol))
                {
                    curRow++;
                    if (char.IsDigit(matrix[curRow, curCol]))
                    {
                        money += (int)Char.GetNumericValue(matrix[curRow, curCol]);
                        matrix[curRow, curCol] = '-';
                    }
                    else if (matrix[curRow, curCol] == 'O')
                    {
                        if (matrix[curRow, curCol] == matrix[pillarOne[0], pillarOne[1]])
                        {
                            curRow = pillarTwo[0];
                            curCol = pillarTwo[1];
                            matrix[curRow, curCol] = '-';
                        }
                        else if (matrix[curRow, curCol] == matrix[pillarTwo[0], pillarTwo[1]])
                        {
                            curRow = pillarOne[0];
                            curCol = pillarOne[1];
                            matrix[curRow, curCol] = '-';
                        }
                    }
                }
                else if (movements == "left" && IsInRange(matrix,curRow, curCol - 1))
                {
                    curCol--;
                    if (char.IsDigit(matrix[curRow, curCol]))
                    {
                        money += (int)Char.GetNumericValue(matrix[curRow, curCol]);
                        matrix[curRow, curCol] = '-';
                    }
                    else if (matrix[curRow, curCol] == 'O')
                    {
                        if (matrix[curRow, curCol] == matrix[pillarOne[0], pillarOne[1]])
                        {
                            curRow = pillarTwo[0];
                            curCol = pillarTwo[1];
                            matrix[curRow, curCol] = '-';
                        }
                        else if (matrix[curRow, curCol] == matrix[pillarTwo[0], pillarTwo[1]])
                        {
                            curRow = pillarOne[0];
                            curCol = pillarOne[1];
                            matrix[curRow, curCol] = '-';
                        }
                    }
                }
                else if (movements == "right" && IsInRange(matrix,curRow,curCol+1))
                {
                    curCol++;
                    if (char.IsDigit(matrix[curRow, curCol]))
                    {
                        
                        money += (int)Char.GetNumericValue(matrix[curRow,curCol]);
                        matrix[curRow, curCol] = '-';
                    }
                    else if (matrix[curRow, curCol] == 'O')
                    {
                        if (matrix[curRow, curCol] == matrix[pillarOne[0], pillarOne[1]])
                        {
                            matrix[curRow, curCol] = '-';
                            curRow = pillarTwo[0];
                            curCol = pillarTwo[1];
                            matrix[curRow, curCol] = '-';
                        }
                        else if (matrix[curRow, curCol] == matrix[pillarTwo[0], pillarTwo[1]])
                        {
                            matrix[curRow, curCol] = '-';
                            curRow = pillarOne[0];
                            curCol = pillarOne[1];
                            matrix[curRow, curCol] = '-';
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {money}");
                    PrintMatrix(matrix);
                    return;
                }
                if (money >= 50)
                {
                    matrix[curRow, curCol] = 'S';
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    Console.WriteLine($"Money: {money}");
                    PrintMatrix(matrix);
                    return;
                }
            }
        }
        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(0))
            {
                return true;
            }
            return false;
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write($"{matrix[rows,cols]}");
                }
                Console.WriteLine();
            }
        }
    }
}
