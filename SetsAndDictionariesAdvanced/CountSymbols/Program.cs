using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> counter = new Dictionary<char, int>();
            var input = Console.ReadLine();
            foreach (var letter in input)
            {
                if (!counter.ContainsKey(letter))
                {
                    counter.Add(letter, 1);
                }
                else
                {
                    counter[letter]++;
                }
            }
            foreach (var item in counter.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
