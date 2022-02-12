using System;

namespace Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows =int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];
            for (int row = 0; row < beach.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                beach[row] = input;
            }
        }
    }
}
