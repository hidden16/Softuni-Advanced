using System;
using System.Collections.Generic;
using System.Linq;
namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<string, bool> filter = n => n.Length <= length ;
            input = input.Where(filter).ToList();
            Console.WriteLine(string.Join("\n",input));
        }
    }
}
