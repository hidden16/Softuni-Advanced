using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(input[i]);
            }
            numbers = numbers.OrderByDescending(n => n).Take(3).ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
