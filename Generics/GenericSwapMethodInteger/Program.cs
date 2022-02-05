using System;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Swap<int> swapper = new Swap<int>();
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                swapper.Swapper.Add(input);
            }
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            swapper.IndexSwapper<int>(indexes[0], indexes[1]);
        }
    }
}
