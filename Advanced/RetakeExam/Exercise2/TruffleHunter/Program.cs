using System;

namespace TruffleHunter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n,n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            var blackTruffles = 0;
            var summerTruffles = 0;
            var whiteTruffles = 0;

            var boarBlackTruffles = 0;
            var boarSummerTruffles = 0;
            var boarWhiteTruffles = 0;

            var commands = Console.ReadLine();
            while (commands != "Stop the hunt")
            {
                var tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                if (tokens[0] == "Collect")
                {
                    if (IsInRange(matrix,row,col))
                    {
                        if (matrix[row,col] == "B")
                        {
                            blackTruffles++;
                        }
                        else if (matrix[row,col] == "S")
                        {
                            summerTruffles++;
                        }
                        else if (matrix[row,col] == "W")
                        {
                            whiteTruffles++;
                        }
                        matrix[row, col] = "-";
                    }
                }
                else if (tokens[0] == "Wild_Boar")
                {
                    var direction = tokens[3];
                    if (IsInRange(matrix,row,col))
                    {
                        if (direction == "up")
                        {
                            while (row >= 0)
                            {
                                if (matrix[row, col] == "B")
                                {
                                    boarBlackTruffles++;
                                }
                                else if (matrix[row, col] == "S")
                                {
                                    boarSummerTruffles++;
                                }
                                else if (matrix[row, col] == "W")
                                {
                                    boarWhiteTruffles++;
                                }
                                matrix[row, col] = "-";
                                row -= 2;
                            }
                        }
                        else if (direction == "down")
                        {
                            while (row < matrix.GetLength(0))
                            {
                                if (matrix[row, col] == "B")
                                {
                                    boarBlackTruffles++;
                                }
                                else if (matrix[row, col] == "S")
                                {
                                    boarSummerTruffles++;
                                }
                                else if (matrix[row, col] == "W")
                                {
                                    boarWhiteTruffles++;
                                }
                                matrix[row, col] = "-";
                                row += 2;
                            }
                        }
                        else if (direction == "left")
                        {
                            while (col >= 0)
                            {
                                if (matrix[row, col] == "B")
                                {
                                    boarBlackTruffles++;
                                }
                                else if (matrix[row, col] == "S")
                                {
                                    boarSummerTruffles++;
                                }
                                else if (matrix[row, col] == "W")
                                {
                                    boarWhiteTruffles++;
                                }
                                matrix[row, col] = "-";
                                col -= 2;
                            }
                        }
                        else if (direction == "right")
                        {
                            while (col < matrix.GetLength(1))
                            {
                                if (matrix[row, col] == "B")
                                {
                                    boarBlackTruffles++;
                                }
                                else if (matrix[row, col] == "S")
                                {
                                    boarSummerTruffles++;
                                }
                                else if (matrix[row, col] == "W")
                                {
                                    boarWhiteTruffles++;
                                }
                                matrix[row, col] = "-";
                                col += 2;
                            }
                        }
                    }
                }

                commands = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarBlackTruffles + boarWhiteTruffles + boarSummerTruffles} truffles.");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] +" ");
                }
                Console.WriteLine();
            }
        }
        public static bool IsInRange(string[,] matrix, int row , int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
