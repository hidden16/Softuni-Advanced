using System;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var currRow = 0;
            var currCol = 0;
            var burrowOne = new int[2];
            var burrowTwo = new int[2];
            bool burrowTwoFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        if (burrowTwoFound == false)
                        {
                            burrowOne[0] = row;
                            burrowOne[1] = col;
                            burrowTwoFound = true;
                        }
                        if (burrowTwoFound == true)
                        {
                            burrowTwo[0] = row;
                            burrowTwo[1] = col;
                        }
                    }
                }
            }
            var foodQuantity = 0;
            matrix[currRow, currCol] = '.';
            bool snakeFed = false;
            bool outOfArray = false;
            while (true)
            {
                var movements = Console.ReadLine();
                if (movements == "up")
                {
                    if (IsInRange(matrix, currRow - 1, currCol))
                    {
                        currRow--;
                        if (matrix[currRow, currCol] == '*')
                        {
                            matrix[currRow, currCol] = '.';
                            foodQuantity++;
                        }
                        else if (matrix[currRow, currCol] == 'B')
                        {
                            matrix[currRow, currCol] = '.';
                            currRow = burrowTwo[0];
                            currCol = burrowTwo[1];
                            matrix[currRow, currCol] = '.';
                        }
                        else
                        {
                            matrix[currRow,currCol] = '.';
                        }
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                }

                if (movements == "down")
                {
                    if (IsInRange(matrix, currRow + 1, currCol))
                    {
                        currRow++;
                        if (matrix[currRow, currCol] == '*')
                        {
                            matrix[currRow, currCol] = '.';
                            foodQuantity++;
                        }
                        else if (matrix[currRow, currCol] == 'B')
                        {
                            matrix[currRow, currCol] = '.';
                            currRow = burrowTwo[0];
                            currCol = burrowTwo[1];
                            matrix[currRow, currCol] = '.';
                        }
                        else
                        {
                            matrix[currRow, currCol] = '.';
                        }
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                }
                if (movements == "left")
                {
                    if (IsInRange(matrix, currRow, currCol - 1))
                    {
                        currCol--;
                        if (matrix[currRow, currCol] == '*')
                        {
                            matrix[currRow, currCol] = '.';
                            foodQuantity++;
                        }
                        else if (matrix[currRow, currCol] == 'B')
                        {
                            matrix[currRow, currCol] = '.';
                            currRow = burrowTwo[0];
                            currCol = burrowTwo[1];
                            matrix[currRow, currCol] = '.';
                        }
                        else
                        {
                            matrix[currRow, currCol] = '.';
                        }
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                }

                if (movements == "right")
                {
                    if (IsInRange(matrix, currRow, currCol + 1))
                    {
                        currCol++;
                        if (matrix[currRow, currCol] == '*')
                        {
                            matrix[currRow, currCol] = '.';
                            foodQuantity++;
                        }
                        else if (matrix[currRow, currCol] == 'B')
                        {
                            matrix[currRow, currCol] = '.';
                            currRow = burrowTwo[0];
                            currCol = burrowTwo[1];
                            matrix[currRow, currCol] = '.';
                        }
                        else
                        {
                            matrix[currRow, currCol] = '.';
                        }
                    }
                    else
                    {
                        outOfArray = true;
                        break;
                    }
                }

                if (foodQuantity >= 10)
                {
                    matrix[currRow, currCol] = 'S';
                    snakeFed = true;
                    break;
                }
            }
            if (snakeFed)
            {
                Console.WriteLine($"You won! You fed the snake.");
            }
            if (outOfArray)
            {
                Console.WriteLine($"Game over!");
            }
            Console.WriteLine($"Food eaten: {foodQuantity}");
            PrintMatrix(matrix);
            /*
             * if (matrix[currRow,currCol] == '*')
                    {
                        matrix[currRow, currCol] = '.';
                        foodQuantity++;
                    }
                    else if (matrix[currRow,currCol] == 'B')
                    {
                        matrix[currRow, currCol] = '.';
                        currRow = burrowTwo[0];
                        currCol = burrowTwo[1];
                        matrix[currRow, currCol] = '.';
                    }
            */
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
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
