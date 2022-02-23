using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new string[n, n];
            var movementsInput = Console.ReadLine().Split(new char[] {' ',','}, StringSplitOptions.RemoveEmptyEntries);
            var playerOne = 0;
            var playerTwo = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == "<")
                    {
                        playerOne++;
                    }
                    else if (matrix[row, col] == ">")
                    {
                        playerTwo++;
                    }
                }
            }
            var destroyedShips = 0;
            destroyedShips = playerOne + playerTwo;
            for (int i = 0; i < movementsInput.Length - 1; i+=2)
            {
                
                var row = int.Parse(movementsInput[i]);
                var col = int.Parse(movementsInput[i + 1]);
                
                if (IsInRange(matrix, row, col))
                {
                    if (matrix[row, col] == ">")
                    {
                        matrix[row, col] = "X";
                        playerTwo--;
                        
                    }
                    else if (matrix[row, col] == "<")
                    {
                        matrix[row, col] = "X";
                        playerOne--;
                        
                    }
                    else if (matrix[row, col] == "#")
                    {
                        matrix[row, col] = "X";
                        // < player one
                        // > player two
                        // up left
                        if (IsInRange(matrix, row - 1, col - 1))
                        {
                            if (matrix[row - 1, col - 1] == "<")
                            {
                                matrix[row-1, col - 1] = "X";
                                playerOne--;
                            }
                            else if (matrix[row -1, col -1] == ">")
                            {
                                matrix[row - 1, col - 1] = "X";
                                playerTwo--;
                            }
                        }
                        //up
                        if (IsInRange(matrix, row - 1, col))
                        {
                            if (matrix[row - 1, col] == "<")
                            {
                                matrix[row - 1, col] = "X";
                                playerOne--;
                            }
                            else if (matrix[row - 1, col] == ">")
                            {
                                matrix[row - 1, col] = "X";
                                playerTwo--;
                            }
                        }
                        // up right
                        if (IsInRange(matrix,row - 1, col +1 ))
                        {
                            if (matrix[row - 1, col + 1] == "<")
                            {
                                matrix[row - 1, col + 1] = "X";
                                playerOne--;
                            }
                            else if (matrix[row - 1, col + 1] == ">")
                            {
                                matrix[row - 1, col + 1] = "X";
                                playerTwo--;
                            }
                        }
                        // left
                        if (IsInRange(matrix, row, col - 1))
                        {
                            if (matrix[row, col - 1] == "<")
                            {
                                matrix[row, col - 1] = "X";
                                playerOne--;
                            }
                            else if (matrix[row, col - 1] == ">")
                            {
                                matrix[row, col - 1] = "X";
                                playerTwo--;
                            }
                        }
                        // right
                        if (IsInRange(matrix,row,col+1))
                        {
                            if (matrix[row,col + 1] == "<")
                            {
                                matrix[row, col + 1] = "X";
                                playerOne--;
                            }
                            else if (matrix[row, col + 1] == ">")
                            {
                                matrix[row, col + 1] = "X";
                                playerTwo--;
                            }
                        }
                        // down left
                        if (IsInRange(matrix,row+1,col-1))
                        {
                            if (matrix[row + 1, col - 1] == "<")
                            {
                                matrix[row + 1, col - 1] = "X";
                                playerOne--;
                            }
                            else if (matrix[row + 1, col - 1] == ">")
                            {
                                matrix[row + 1, col - 1] = "X";
                                playerTwo--;
                            }
                        }
                        // down
                        if (IsInRange(matrix, row + 1, col))
                        {
                            if (matrix[row + 1, col] == "<")
                            {
                                matrix[row + 1, col] = "X";
                                playerOne--;
                            }
                            else if (matrix[row + 1, col] == ">")
                            {
                                matrix[row + 1, col] = "X";
                                playerTwo--;
                            }
                        }
                        // down right
                        if (IsInRange(matrix,row +1, col + 1))
                        {
                            if (matrix[row + 1, col + 1] == "<")
                            {
                                matrix[row + 1, col + 1] = "X";
                                playerOne--;
                            }
                            else if (matrix[row + 1, col + 1] == ">")
                            {
                                matrix[row + 1, col + 1] = "X";
                                playerTwo--;
                            }
                        }
                    }
                }
                if (playerOne == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {destroyedShips - (playerOne + playerTwo)} ships have been sunk in the battle.");
                    return;
                }
                else if (playerTwo == 0)
                {
                    Console.WriteLine($"Player One has won the game! {destroyedShips - (playerOne + playerTwo)} ships have been sunk in the battle.");
                    return;
                }
            }
            Console.WriteLine($"It's a draw! Player One has {playerOne} ships left. Player Two has {playerTwo} ships left.");
        }
        public static bool IsInRange(string[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
