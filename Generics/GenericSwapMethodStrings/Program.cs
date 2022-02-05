using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Swap<string> swapper = new Swap<string>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                swapper.Names.Add(input);
            }
            var indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var indexOne = indexes[0];
            var indexTwo = indexes[1];
            swapper.Swapper<string>(indexOne, indexTwo);
        }
    }
}
