using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());
            Func<int, bool> filter = n => n % divider != 0;
            var finalNumbers = numbers.Reverse().Where(filter);
            Console.WriteLine(string.Join(" ",finalNumbers));
        }
    }
}
