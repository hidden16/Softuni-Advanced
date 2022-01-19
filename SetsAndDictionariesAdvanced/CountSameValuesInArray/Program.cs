using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> counter = new Dictionary<double, int>();
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            foreach (var number in input)
            {
                if (!counter.ContainsKey(number))
                {
                    counter.Add(number, 0);
                }
                counter[number]++;
            }
            foreach (var value in counter)
            {
                Console.WriteLine($"{value.Key} - {value.Value} times");
            }
        }
    }
}
