using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Queue<double> water = new Queue<double>(input1);
            Stack<double> flour = new Stack<double>(input2);
            Dictionary<string, int> baked = new Dictionary<string, int>()
            {
                {"Croissant", 0 },
                {"Muffin", 0 },
                {"Baguette", 0 },
                {"Bagel", 0 }
            };
            while (water.Count != 0 && flour.Count != 0)
            {
                var sum = water.Peek() + flour.Peek();
                var percentages = (water.Peek() * 100) / sum;
                if (percentages == 50)
                {
                    baked["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (percentages == 40)
                {
                    baked["Muffin"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (percentages == 30)
                {
                    baked["Baguette"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (percentages == 20)
                {
                    baked["Bagel"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    var toPush = flour.Peek() - water.Peek();
                    while (water.Peek() != flour.Peek())
                    {
                        flour.Push(flour.Pop() - toPush);
                    }
                    if (water.Peek() == flour.Peek())
                    {
                        baked["Croissant"]++;
                        water.Dequeue();
                        flour.Pop();
                        flour.Push(toPush);
                    }
                }
            }
            foreach (var product in baked.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
            if (water.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine($"Water left: None");
            }
            if (flour.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine($"Flour left: None");
            }
        }
    }
}
