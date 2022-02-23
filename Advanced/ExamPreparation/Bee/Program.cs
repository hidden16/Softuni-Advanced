using System;

namespace Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var currRow = 0;
            var currCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row,col] == 'B')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            matrix[currRow, currCol] = '.';
            var pollinated = 0;
            bool outOfArray = false;
            while (true)
            {
                var movements = Console.ReadLine();
                if (movements == "End")
                {
                    matrix[currRow, currCol] = 'B';
                    break;
                }
                if (movements == "up")
                {
                    if (IsInRange(matrix, currRow - 1, currCol))
                    {
                        currRow--;
                        if (matrix[currRow,currCol] == 'f')
                        {
                            matrix[currRow, currCol] = '.';
                            pollinated++;
                        }
                        else if (matrix[currRow, currCol] == 'O')
                        {
                            matrix[currRow, currCol] = '.';
                            if (IsInRange(matrix,currRow - 1, currCol))
                            {
                                currRow--;
                                if (matrix[currRow, currCol] == 'f')
                                {
                                    matrix[currRow, currCol] = '.';
                                    pollinated++;
                                }
                            }
                            else
                            {
                                outOfArray = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                }
                else if (movements == "down")
                {
                    if (IsInRange(matrix, currRow + 1, currCol))
                    {
                        currRow++;
                        if (matrix[currRow, currCol] == 'f')
                        {
                            matrix[currRow, currCol] = '.';
                            pollinated++;
                        }
                        else if (matrix[currRow, currCol] == 'O')
                        {
                            matrix[currRow, currCol] = '.';
                            if (IsInRange(matrix, currRow + 1, currCol))
                            {
                                currRow++;
                                if (matrix[currRow, currCol] == 'f')
                                {
                                    matrix[currRow, currCol] = '.';
                                    pollinated++;
                                }
                            }
                            else
                            {
                                outOfArray = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                }
                else if (movements == "left")
                {
                    if (IsInRange(matrix, currRow, currCol - 1))
                    {
                        currCol--;
                        if (matrix[currRow, currCol] == 'f')
                        {
                            matrix[currRow, currCol] = '.';
                            pollinated++;
                        }
                        else if (matrix[currRow, currCol] == 'O')
                        {
                            matrix[currRow, currCol] = '.';
                            if (IsInRange(matrix, currRow, currCol - 1))
                            {
                                currCol--;
                                if (matrix[currRow, currCol] == 'f')
                                {
                                    matrix[currRow, currCol] = '.';
                                    pollinated++;
                                }
                            }
                            else
                            {
                                outOfArray = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                }
                else if (movements == "right")
                {
                    if (IsInRange(matrix, currRow, currCol + 1))
                    {
                        currCol++;
                        if (matrix[currRow, currCol] == 'f')
                        {
                            matrix[currRow, currCol] = '.';
                            pollinated++;
                        }
                        else if (matrix[currRow, currCol] == 'O')
                        {
                            matrix[currRow, currCol] = '.';
                            if (IsInRange(matrix, currRow, currCol + 1))
                            {
                                currCol++;
                                if (matrix[currRow, currCol] == 'f')
                                {
                                    matrix[currRow, currCol] = '.';
                                    pollinated++;
                                }
                            }
                            else
                            {
                                outOfArray = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                }
            }
            if (outOfArray)
            {
                Console.WriteLine($"The bee got lost!");
            }
            if (pollinated >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinated} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinated} flowers more");
            }
            PrintMatrix(matrix);
        }
        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
