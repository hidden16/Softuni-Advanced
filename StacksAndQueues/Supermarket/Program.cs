﻿using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            var input = Console.ReadLine();
            while (input != "End")
            {
                if (input != "Paid")
                {
                    queue.Enqueue(input);
                }
                if (input == "Paid")
                {
                    while (queue.Count != 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
