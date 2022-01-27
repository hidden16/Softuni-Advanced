using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> printer = input => Console.WriteLine($"Sir {input}");
            for (int i = 0; i < input.Length; i++)
            {
                printer(input[i]);
            }
        }
    }
}
