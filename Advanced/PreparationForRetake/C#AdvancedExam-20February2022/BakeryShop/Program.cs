using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            // water calculation (16.8 + 25.2 = 42; (16.8 * 100)/42 = 40% water)  --- 16.8 (Water) 25.2 (flour)
            var waterInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var flourInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Queue<double> water = new Queue<double>(waterInput);
            Stack<double> flour = new Stack<double>(flourInput);
            Dictionary<string, int> bakedProducts = new Dictionary<string, int>
            {
                {"Croissant",0 },
                {"Muffin",0 },
                {"Baguette",0 },
                {"Bagel",0 }
            };

            while (water.Count > 0 && flour.Count > 0)
            {
                var sum = water.Peek() + flour.Peek();
                var calculation = (water.Peek() * 100) / sum;
                if (calculation == 50)
                {
                    bakedProducts["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (calculation == 40)
                {
                    bakedProducts["Muffin"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (calculation == 30)
                {
                    bakedProducts["Baguette"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (calculation == 20)
                {
                    bakedProducts["Bagel"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    var excess = flour.Peek() - water.Peek();
                    flour.Push(flour.Pop() - excess);
                    bakedProducts["Croissant"]++;
                    flour.Pop();
                    water.Dequeue();
                    flour.Push(excess);
                }
            }
            foreach (var product in bakedProducts.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key).Where(x=>x.Value > 0))
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
