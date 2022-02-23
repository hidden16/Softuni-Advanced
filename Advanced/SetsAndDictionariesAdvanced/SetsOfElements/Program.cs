using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var iterations = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();
            for (int i = 0; i < iterations[0]; i++)
            {
                var input = int.Parse(Console.ReadLine());
                setOne.Add(input);
            }
            for (int i = 0; i < iterations[1]; i++)
            {
                var input = int.Parse(Console.ReadLine());
                setTwo.Add(input);
            }
            foreach (var item in setOne)
            {
                foreach (var number in setTwo)
                {
                    if (number == item)
                    {
                        Console.Write($"{number} ");
                    }
                }
            }
        }
    }
}
