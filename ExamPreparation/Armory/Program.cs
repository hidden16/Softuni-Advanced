using System;
using System.Collections.Generic;
using System.Linq;

namespace Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var armory = new char[n, n];
            for (int rows = 0; rows < armory.GetLength(0); rows++)
            {
                string input = Console.ReadLine();
                var inputToChar = input.ToCharArray();
                for (int cols = 0; cols < armory.GetLength(1); cols++)
                {
                    armory[rows, cols] = inputToChar[cols];
                }
            }
            bool outOfArmory = false;
            int newRow = 0;
            int newCol = 0;
            var mirrorFoundCounter = 0;
            int[] mirror1 = new int[2];
            int[] mirror2 = new int[2];
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row, col] == 'A')
                    {
                        newRow = row;
                        newCol = col;
                    }
                    if (armory[row, col] == 'M')
                    {
                        if (mirrorFoundCounter < 1)
                        {
                            mirror1[0] = row;
                            mirror1[1] = col;
                        }
                        else
                        {
                            mirror2[0] = row;
                            mirror2[1] = col;
                        }
                        mirrorFoundCounter++;
                    }
                }
            }
            var coins = 0;
            List<int> coinsTaken = new List<int>();
            bool isM = false;
            while (true)
            {
                string direction = Console.ReadLine();
                switch (direction.ToLower())
                {
                    case "up":
                        newRow -= 1;
                        break;
                    case "down":
                        newRow += 1;
                        break;
                    case "left":
                        newCol -= 1;
                        break;
                    case "right":
                        newCol += 1;
                        break;
                    default:
                        continue;
                }
                if (!(newRow >= 0 && newRow < armory.GetLength(0) && newCol >= 0 && newCol < armory.GetLength(1)))
                {
                    outOfArmory = true;
                    switch (direction)
                    {
                        case "up":
                            armory[newRow + 1, newCol] = '-';
                            break;
                        case "down":
                            armory[newRow - 1, newCol] = '-';
                            break;
                        case "left":
                            armory[newRow, newCol + 1] = '-';
                            break;
                        case "right":
                            armory[newRow, newCol - 1] = '-';
                            break;
                        default:
                            break;
                    }
                    break;
                }
                if (armory[newRow,newCol] =='M')
                {

                    isM = true;
                }
                Movements(direction, armory, newRow, newCol, coins, mirror1, mirror2, coinsTaken);
                if (isM)
                {
                    newRow = mirror2[0];
                    newCol = mirror2[1];
                    isM = false;
                }
                if (coinsTaken.Sum() >= 65)
                {
                    CoinPrint(coinsTaken, armory);
                    return;
                }
            }
            if (outOfArmory)
            {
                OutOfArmory(coinsTaken, armory);
                return;
            }
        }
        public static void Movements(string directions, char[,] armory, int newRow, int newCol, int coins, int[] mirror1, int[] mirror2, List<int> coinsTaken)
        {
            if (directions == "up")
            {
                if (char.IsDigit(armory[newRow, newCol]))
                {
                    var num = armory[newRow, newCol].ToString();
                    coinsTaken.Add(int.Parse(num));
                    armory[newRow, newCol] = 'A';
                    armory[newRow + 1, newCol] = '-';
                }
                else if (armory[newRow, newCol] == '-')
                {
                    armory[newRow, newCol] = 'A';
                    armory[newRow + 1, newCol] = '-';
                }
                else if (armory[newRow, newCol] == 'M')
                {
                    armory[newRow + 1, newCol] = '-';
                    newRow = mirror2[0];
                    newCol = mirror2[1];
                    armory[mirror1[0], mirror1[1]] = '-';
                    armory[newRow, newCol] = 'A';
                }
            }
            else if (directions == "down")
            {
                if (char.IsDigit(armory[newRow, newCol]))
                {
                    var num = armory[newRow, newCol].ToString();
                    coinsTaken.Add(int.Parse(num));
                    armory[newRow, newCol] = 'A';
                    armory[newRow - 1, newCol] = '-';
                }
                else if (armory[newRow, newCol] == '-')
                {
                    armory[newRow, newCol] = 'A';
                    armory[newRow - 1, newCol] = '-';
                }
                else if (armory[newRow, newCol] == 'M')
                {
                    armory[newRow - 1, newCol] = '-';
                    newRow = mirror2[0];
                    newCol = mirror2[1];
                    armory[mirror1[0], mirror1[1]] = '-';
                    armory[newRow, newCol] = 'A';
                }
            }
            else if (directions == "right")
            {
                if (char.IsDigit(armory[newRow, newCol]))
                {
                    var num = armory[newRow, newCol].ToString();
                    coinsTaken.Add(int.Parse(num));
                    armory[newRow, newCol] = 'A';
                    armory[newRow, newCol - 1] = '-';
                }
                else if (armory[newRow, newCol] == '-')
                {
                    armory[newRow, newCol] = 'A';
                    armory[newRow, newCol - 1] = '-';
                }
                else if (armory[newRow, newCol] == 'M')
                {
                    armory[newRow, newCol - 1] = '-';
                    newRow = mirror2[0];
                    newCol = mirror2[1];
                    armory[mirror1[0], mirror1[1]] = '-';
                    armory[newRow, newCol] = 'A';
                }
            }
            else if (directions == "left")
            {
                if (char.IsDigit(armory[newRow, newCol]))
                {
                    var num = armory[newRow, newCol].ToString();
                    coinsTaken.Add(int.Parse(num));
                    armory[newRow, newCol] = 'A';
                    armory[newRow, newCol + 1] = '-';
                }
                else if (armory[newRow, newCol] == '-')
                {
                    armory[newRow, newCol] = 'A';
                    armory[newRow, newCol + 1] = '-';
                }
                else if (armory[newRow, newCol] == 'M')
                {
                    armory[newRow, newCol + 1] = '-';
                    newRow = mirror2[0];
                    newCol = mirror2[1];
                    armory[mirror1[0], mirror1[1]] = '-';
                    armory[newRow, newCol] = 'A';
                }
            }
        }
        public static void CoinPrint(List<int> coins, char[,] armory)
        {
            Console.WriteLine("Very nice swords, I will come back for more!");
            Console.WriteLine($"The king paid {coins.Sum()} gold coins.");
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write($"{armory[row, col]}");
                }
                Console.WriteLine();
            }
        }
        public static void OutOfArmory(List<int> coins, char[,] armory)
        {
            Console.WriteLine("I do not need more swords!");
            Console.WriteLine($"The king paid {coins.Sum()} gold coins.");
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    Console.Write($"{armory[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
