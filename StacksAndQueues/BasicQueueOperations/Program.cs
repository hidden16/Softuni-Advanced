using System;
using System.Collections.Generic;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(input[0]);
            var toDequeue = int.Parse(input[1]);
            var toLook = int.Parse(input[2]);
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(int.Parse(numbers[i]));
            }
            for (int i = 0; i < toDequeue; i++)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("0");
                    return;
                }
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (queue.Contains(toLook))
            {
                Console.WriteLine($"true");
                return;
            }
            int lowest = int.MaxValue;
            foreach (var item in queue)
            {
                if (item < lowest)
                {
                    lowest = item;
                }
            }
            Console.WriteLine(lowest);
        }
    }
}
