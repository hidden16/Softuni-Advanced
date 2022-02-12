using System;

namespace Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows =int.Parse(Console.ReadLine());
            string[][] beach = new string[rows][];
            for (int row = 0; row < beach.Length; row++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                beach[row] = new string[input.Length];
                for (int col = 0; col < beach[row].Length; col++)
                {
                    beach[row][col] = input[col];
                }
            }
            var collected = 0;
            var enemyCollected = 0;
            var commands = Console.ReadLine();
            while (commands != "Gong")
            {
                var splitted = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (splitted[0] == "Find")
                {
                    var row = int.Parse(splitted[1]);
                    var col = int.Parse(splitted[2]);
                    if (IndexValidator(beach, row, col) && beach[row][col] == "T")
                    {
                        beach[row][col] = "-";
                        collected++;
                    }
                }
                else if (splitted[0] == "Opponent")
                {
                    var row = int.Parse(splitted[1]);
                    var col = int.Parse(splitted[2]);
                    var direction = splitted[3];
                    if (IndexValidator(beach, row, col) && beach[row][col] == "T")
                    {
                        enemyCollected++;
                        beach[row][col] = "-";
                        if (direction == "up")
                        {
                            for (int i = 1; i <= 3; i++)
                            {
                                if (row - i >= 0 && beach[row - i][col] == "T")
                                {
                                    enemyCollected++;
                                    beach[row - i][col] = "-";
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = 1; i <= 3; i++)
                            {
                                if (row >= 0 && row + i < beach.Length && beach[row + i][col] == "T")
                                {
                                    enemyCollected++;
                                    beach[row + i][col] = "-";
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = 1; i <= 3; i++)
                            {
                                if (col - i >= 0 && beach[row][col - i] == "T")
                                {
                                    enemyCollected++;
                                    beach[row][col - i] = "-";
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = 1; i <= 3; i++)
                            {
                                if (col + i >= 0 && col + i < beach[row].Length && beach[row][col + i] == "T")
                                {
                                    enemyCollected++;
                                    beach[row][col + i] = "-";
                                }
                            }
                        }
                    }
                }

                commands = Console.ReadLine();
            }
            for (int row = 0; row < beach.Length; row++)
            {
                for (int col = 0;col< beach[row].Length; col++)
                {
                    Console.Write($"{beach[row][col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Collected tokens: {collected}");
            Console.WriteLine($"Opponent's tokens: {enemyCollected}");
        }
        public static bool IndexValidator(string[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
