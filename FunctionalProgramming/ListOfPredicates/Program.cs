using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }
            int[] divisibles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < divisibles.Length; i++)
            {
                Func<int, bool> filter = n => n % divisibles[i] == 0;
                numbers = numbers.Where(filter).ToList();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
