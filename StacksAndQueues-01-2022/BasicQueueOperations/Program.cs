using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> qu = new Queue<int>();
            var toEnqeueue = input[0];
            var toDequeue = input[1];
            var toLookFor = input[2];
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            qu = new Queue<int>(numbers);
            for (int i = 0; i < toDequeue; i++)
            {
                qu.Dequeue();
            }
            var smallestElement = int.MaxValue;
            if (qu.Contains(toLookFor))
            {
                Console.WriteLine($"true");
            }
            else
            {
                if (qu.Count > 0)
                {
                    while (qu.Count > 0)
                    {
                        var saveLastNum = qu.Peek() ;
                        if (qu.Dequeue() < smallestElement)
                        {
                            smallestElement = saveLastNum;
                        }
                    }
                    Console.WriteLine(smallestElement);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
