using System;

namespace ReVolt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cmdCount = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var currRow = 0;
            var currCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'f')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            var isF = false;
            for (int i = 0; i < cmdCount; i++)
            {
                var directions = Console.ReadLine();
                matrix[currRow, currCol] = '-';
                if (directions == "up")
                {
                    var isInside = IsInMatrix(matrix, currRow - 1, currCol);
                    currRow = isInside == true ? currRow - 1 : matrix.GetLength(0) - 1;
                    while (matrix[currRow, currCol] != '-' && matrix[currRow, currCol] != 'F')
                    {
                        if (matrix[currRow, currCol] == 'B')
                        {
                            isInside = IsInMatrix(matrix, currRow - 1, currCol);
                            currRow = isInside == true ? currRow - 1 : matrix.GetLength(0) - 1;
                        }
                        else if (matrix[currRow, currCol] == 'T')
                        {
                            isInside = IsInMatrix(matrix, currRow + 1, currCol);
                            currRow = isInside == true ? currRow + 1 : 0;
                        }
                    }
                    if (matrix[currRow,currCol] == 'F')
                    {
                        isF = true;
                        break;
                    }
                }
                else if (directions == "down")
                {
                    var isInside = IsInMatrix(matrix, currRow + 1, currCol);
                    currRow = isInside == true ? currRow + 1 : 0;
                    while (matrix[currRow, currCol] != '-' && matrix[currRow, currCol] != 'F')
                    {
                        if (matrix[currRow, currCol] == 'B')
                        {
                            isInside = IsInMatrix(matrix, currRow + 1, currCol);
                            currRow = isInside == true ? currRow + 1 : 0;
                        }
                        else if (matrix[currRow, currCol] == 'T')
                        {
                            isInside = IsInMatrix(matrix, currRow - 1, currCol);
                            currRow = isInside == true ? currRow - 1 : matrix.GetLength(0) - 1;
                        }
                    }
                    if (matrix[currRow, currCol] == 'F')
                    {
                        isF = true;
                        break;
                    }
                }
                else if (directions == "left")
                {
                    var isInside = IsInMatrix(matrix, currRow, currCol - 1);
                    currCol = isInside == true ? currCol - 1 : matrix.GetLength(1) - 1;
                    while (matrix[currRow,currCol] != '-' && matrix[currRow,currCol] != 'F')
                    {
                        if (matrix[currRow,currCol] == 'B')
                        {
                            isInside = IsInMatrix(matrix, currRow, currCol - 1);
                            currCol = isInside == true ? currCol - 1 : matrix.GetLength(1) - 1;
                        }
                        else if (matrix[currRow,currCol] == 'T')
                        {
                            isInside = IsInMatrix(matrix, currRow, currCol + 1);
                            currCol = isInside == true ? currCol + 1 : 0;
                        }
                    }
                    if (matrix[currRow, currCol] == 'F')
                    {
                        isF = true;
                        break;
                    }
                }
                else if (directions == "right")
                {
                    var isInside = IsInMatrix(matrix, currRow, currCol + 1);
                    currCol = isInside == true ? currCol + 1 : 0;
                    while (matrix[currRow, currCol] != '-' && matrix[currRow, currCol] != 'F')
                    {
                        if (matrix[currRow, currCol] == 'B')
                        {
                            isInside = IsInMatrix(matrix, currRow, currCol + 1);
                            currCol = isInside == true ? currCol + 1 : 0;
                        }
                        else if (matrix[currRow, currCol] == 'T')
                        {
                            isInside = IsInMatrix(matrix, currRow, currCol - 1);
                            currCol = isInside == true ? currCol - 1 : matrix.GetLength(1) - 1;
                        }
                    }
                    if (matrix[currRow, currCol] == 'F')
                    {
                        isF = true;
                        break;
                    }
                }
            }
            if (isF)
            {
                matrix[currRow, currCol] = 'f';
                Console.WriteLine("Player won!");
                PrintMatrix(matrix);
            }
            else
            {
                matrix[currRow, currCol] = 'f';
                Console.WriteLine("Player lost!");
                PrintMatrix(matrix);
            }
        }

        public static bool IsInMatrix(char[,] matrix, int row, int col)
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
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
