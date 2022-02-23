using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> numbers = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();
            numbers = numbers.Select(x => x * 1.2m).ToList();
            numbers.ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
