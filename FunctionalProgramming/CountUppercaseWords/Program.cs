using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> uppercaseLetters = x => char.IsUpper(x[0]);
            Console.WriteLine(string.Join("\n",input.Where(uppercaseLetters)));
        }
    }
}
