using System;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = input => Console.WriteLine(input);
            for (int i = 0; i < input.Length; i++)
            {
                print(input[i]);
            }
            
        }
    }
}
