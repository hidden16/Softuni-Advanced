using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            var jaggedRows = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[jaggedRows][];
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArr[row] = new int[input.Length];
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    jaggedArr[row][col] = input[col];
                }
            }
            var cmds = Console.ReadLine();
            while (cmds!="END")
            {
                var tokens = cmds.Split();
                if (tokens[0] == "Add")
                {
                    var row = int.Parse(tokens[1]);
                    var col = int.Parse(tokens[2]);
                    var value = int.Parse(tokens[3]);
                    if (row >= 0 && row < jaggedArr.Length && col >=0 && col < jaggedArr[row].Length)
                    {
                        jaggedArr[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (tokens[0] == "Subtract")
                {
                    var row = int.Parse(tokens[1]);
                    var col = int.Parse(tokens[2]);
                    var value = int.Parse(tokens[3]);
                    if (row >= 0 && row < jaggedArr.Length && col >= 0 && col < jaggedArr[row].Length)
                    {
                        jaggedArr[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }

                cmds = Console.ReadLine();
            }
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write($"{jaggedArr[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
