using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var commands = Console.ReadLine();
            while (commands != "end")
            {
                switch (commands)
                {
                    case "add":
                        numbers = numbers.Select(n => n + 1).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => n * 2).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => n - 1).ToArray();
                        break;
                    case "print":
                        foreach (var number in numbers)
                        {
                            Console.Write($"{number} ");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
                commands = Console.ReadLine();
            }
        }
    }
}
