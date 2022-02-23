using System;
using System.Collections.Generic;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> orders = new Queue<int>();
            var food = int.Parse(Console.ReadLine());
            var ordersQuantity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var biggestOrder = int.MinValue;
            for (int i = 0; i < ordersQuantity.Length; i++)
            {
                if (int.Parse(ordersQuantity[i]) > biggestOrder)
                {
                    biggestOrder = int.Parse(ordersQuantity[i]);
                }
                orders.Enqueue(int.Parse(ordersQuantity[i]));
            }
            Console.WriteLine(biggestOrder);
            while (true)
            {
                if (orders.Count == 0)
                {
                    Console.WriteLine($"Orders complete");
                    return;
                }
                if (food - orders.Peek() >= 0)
                {
                    food -= orders.Dequeue();
                }
                else
                {
                    Console.Write("Orders left: ");
                    foreach (var item in orders)
                    {
                        Console.Write(item + " ");
                    }
                    return;
                }
            }

        }
    }
}
