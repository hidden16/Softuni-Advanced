using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> qu = new Queue<string>();
            var commands = Console.ReadLine();
            while (commands!="End")
            {
                if (commands!= "Paid")
                {
                    qu.Enqueue(commands);
                }
                else
                {
                    while (qu.Count > 0)
                    {
                        Console.WriteLine(qu.Dequeue());
                    }
                }

                commands = Console.ReadLine();
            }
            Console.WriteLine($"{qu.Count} people remaining.");
        }
    }
}
