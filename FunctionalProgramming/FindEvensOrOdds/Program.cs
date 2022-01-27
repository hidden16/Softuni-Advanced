using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numRange = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            if (numRange[0] < numRange[1])
            {
                for (int i = numRange[0]; i <= numRange[1]; i++)
                {
                    numbers.Add(i);
                }
            }
            else
            {
                for (int i = numRange[1]; i <= numRange[0]; i++)
                {
                    numbers.Add(i);
                }
            }
            Predicate<int> evenChecker = n => n % 2 == 0 || n % 2 == -1;
            Predicate<int> oddChecker = n => n % 2 == 1 || n % 2 == -1;
            var input = Console.ReadLine();
            switch (input)
            {
                case "odd":
                    numbers = numbers.Where(w => oddChecker(w)).ToList();
                    numbers.ForEach(w => Console.Write($"{w} "));
                    break;
                case "even":
                    numbers = numbers.Where(w => evenChecker(w)).ToList();
                    numbers.ForEach(w => Console.Write($"{w} "));
                    break;
                default:
                    break;
            }

        }
    }
}
