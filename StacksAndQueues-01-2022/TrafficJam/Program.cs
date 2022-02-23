using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int passedNum = int.Parse(Console.ReadLine());
            Queue<string> qu = new Queue<string>();
            var cmds = Console.ReadLine();
            var counter = 0;
            while (cmds != "end")
            {
                if (cmds != "green")
                {
                    qu.Enqueue(cmds);
                }
                else
                {
                    for (int i = 0; i < passedNum; i++)
                    {
                        if (qu.Count > 0)
                        {
                            Console.WriteLine($"{qu.Dequeue()} passed!");
                            counter++;
                        }
                    }
                }

                cmds = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
