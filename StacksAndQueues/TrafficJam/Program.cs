using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int pass = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            var input = Console.ReadLine();
            int counter = 0;
            while (input != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < pass; i++)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
