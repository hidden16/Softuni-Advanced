using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> evenNums = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                if (!evenNums.ContainsKey(input))
                {
                    evenNums.Add(input, 1);
                }
                else
                {
                    evenNums[input]++;
                }
            }
            foreach (var number in evenNums)
            {
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                    break;
                }
            }
        }
    }
}
