using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int, int> min = n => MinNum(input);
            Console.WriteLine(min(input[0]));
        }
        public static int MinNum(int[] input)
        {
            var minVal = int.MaxValue;
            var minNum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < minVal)
                {
                    minVal = input[i];
                    minNum = input[i];
                }
            }
            return minNum;
        }
    }
}
