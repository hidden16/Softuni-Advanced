using System;
using System.Collections.Generic;
using System.Linq;
namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<char> queue = new Queue<char>();
            Queue<string> cars = new Queue<string>();
            int passed = 0;
            var commands = Console.ReadLine();
            while (commands != "END")
            {
                var checker = string.Empty;
                if (commands != "green")
                {
                    for (int i = 0; i < commands.Length; i++)
                    {
                        queue.Enqueue(commands[i]);
                    }
                    cars.Enqueue(commands);
                }
                else
                {
                    for (int k = 0; k < greenDuration; k++)
                    {
                        if (queue.Count > 0)
                        {
                            checker += queue.Dequeue();
                        }
                        if (cars.Count > 0)
                        {
                            if (cars.Peek() == checker)
                            {
                                passed++;
                                checker = "";
                                cars.Dequeue();
                            }
                        }
                    }
                    for (int z = 0; z < freeWindow; z++)
                    {
                        if (queue.Count > 0)
                        {
                            checker += queue.Dequeue();
                        }
                        if (cars.Count > 0)
                        {
                            if (cars.Peek() == checker)
                            {
                                passed++;
                                checker = "";
                                cars.Dequeue();
                                break;
                            }
                        }
                    }
                    if (checker.Length > 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{cars.Dequeue()} was hit at {queue.Dequeue()}.");
                        return;
                    }
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{passed} total cars passed the crossroads.");
        }
    }
}
