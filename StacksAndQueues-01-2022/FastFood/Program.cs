using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQty = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            var biggestOrder = int.MinValue;
            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i] > biggestOrder)
                {
                    biggestOrder = orders[i];
                }
            }
            while (queue.Count > 0)
            {
                if (foodQty - queue.Peek() > 0)
                {
                    foodQty -= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine($"Orders complete");
            }
            else
            {
                Console.WriteLine(biggestOrder);
                Console.Write($"Orders left: ");
                while (queue.Count > 0)
                {
                    Console.Write($"{queue.Dequeue()} ");
                }
            }

        }
    }
}
