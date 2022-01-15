using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new char[dimensions[0], dimensions[1]];
            var snake = Console.ReadLine();
            Queue<char> snakes = new Queue<char>();
            for (int i = 0; i < dimensions[0] * dimensions[1]; i++)
            {
                for (int z = 0; z < snake.Length; z++)
                {
                    snakes.Enqueue(snake[z]);
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snakes.Dequeue();
                }
                    row++;
                if (row >= matrix.GetLength(0))
                {
                    break;
                }
                for (int colBackwards = matrix.GetLength(1) - 1; colBackwards >= 0; colBackwards--)
                {
                    matrix[row, colBackwards] = snakes.Dequeue(); 
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
