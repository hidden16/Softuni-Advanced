using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Queue<string> qu = new Queue<string>(input);
            int tosses = int.Parse(Console.ReadLine());
            var counter = 1;
            while (qu.Count > 1)
            {
                if (counter == tosses)
                {
                    Console.WriteLine($"Removed {qu.Dequeue()}");
                    counter = 1;
                }
                else
                {
                    qu.Enqueue(qu.Dequeue());
                    counter++;
                }
            }
            Console.WriteLine($"Last is {qu.Dequeue()}");
        }
    }
}
