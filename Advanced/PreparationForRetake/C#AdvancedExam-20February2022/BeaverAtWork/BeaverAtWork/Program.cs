using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            var currRow = 0;
            var currCol = 0;
            int numberOfBranches = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'B')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    if (char.IsLower(matrix[row, col]))
                    {
                        numberOfBranches++;
                    }
                }
            }
            var commands = Console.ReadLine();
            List<char> collectedBranches = new List<char>();
            while (commands != "end")
            {
                if (commands == "up" && IsInRange(matrix, currRow - 1, currCol))
                {
                    matrix[currRow, currCol] = '-';
                    currRow--;
                    if (char.IsLower(matrix[currRow, currCol]))
                    {
                        collectedBranches.Add(matrix[currRow,currCol]);
                        matrix[currRow, currCol] = 'B';
                        numberOfBranches--;
                    }
                    else if (matrix[currRow, currCol] == 'F')
                    {
                        matrix[currRow, currCol] = '-';
                        if (currRow == 0)
                        {
                            currRow = matrix.GetLength(0) - 1;
                            matrix[currRow, currCol] = 'B';
                        }
                        else
                        {
                            currRow = 0;
                            matrix[currRow, currCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[currRow, currCol] = 'B';
                    }
                }
                else if (commands == "down" && IsInRange(matrix, currRow + 1, currCol))
                {
                    matrix[currRow, currCol] = '-';
                    currRow++;
                    if (char.IsLower(matrix[currRow, currCol]))
                    {
                        collectedBranches.Add(matrix[currRow, currCol]);
                        matrix[currRow, currCol] = 'B';

                        numberOfBranches--;
                    }
                    else if (matrix[currRow, currCol] == 'F')
                    {
                        matrix[currRow, currCol] = '-';

                        if (currRow == matrix.GetLength(0) - 1)
                        {
                            currRow = 0;
                            matrix[currRow, currCol] = 'B';
                        }
                        else
                        {
                            currRow = matrix.GetLength(0) - 1;
                            matrix[currRow, currCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[currRow, currCol] = 'B';
                    }
                }
                else if (commands == "left" && IsInRange(matrix, currRow, currCol - 1))
                {
                    matrix[currRow, currCol] = '-';
                    currCol--;
                    if (char.IsLower(matrix[currRow, currCol]))
                    {
                        collectedBranches.Add(matrix[currRow, currCol]);
                        matrix[currRow, currCol] = 'B';

                        numberOfBranches--;
                    }
                    else if (matrix[currRow, currCol] == 'F')
                    {
                        matrix[currRow, currCol] = '-';
                        if (currCol == 0)
                        {
                            currCol = matrix.GetLength(1) - 1;
                            matrix[currRow, currCol] = 'B';
                        }
                        else
                        {
                            currCol = 0;
                            matrix[currRow, currCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[currRow, currCol] = 'B';
                    }
                }
                else if (commands == "right" && IsInRange(matrix, currRow, currCol + 1))
                {
                    matrix[currRow, currCol] = '-';
                    currCol++;
                    if (char.IsLower(matrix[currRow, currCol]))
                    {
                        collectedBranches.Add(matrix[currRow, currCol]);
                        matrix[currRow, currCol] = 'B';

                        numberOfBranches--;
                    }
                    else if (matrix[currRow, currCol] == 'F')
                    {
                        matrix[currRow, currCol] = '-';
                        if (currCol == matrix.GetLength(1) - 1)
                        {
                            currCol = 0;
                            matrix[currRow, currCol] = 'B';
                        }
                        else
                        {
                            currCol = matrix.GetLength(1) - 1;
                            matrix[currRow, currCol] = 'B';
                        }
                    }
                    else
                    {
                        matrix[currRow, currCol] = 'B';
                    }
                }
                else
                {
                    if (collectedBranches.Count > 0)
                    {
                        collectedBranches.RemoveAt(collectedBranches.Count - 1);
                    }
                }
                if (numberOfBranches == 0)
                {
                    break;
                }
                commands = Console.ReadLine();
            }
            if (numberOfBranches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood branches: {string.Join(", ", collectedBranches)}. ");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {numberOfBranches} branches left.");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
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
