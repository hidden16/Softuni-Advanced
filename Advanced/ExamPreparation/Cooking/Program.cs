using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    public class Program
    {
        static void Main(string[] args)
        {
            var liquidsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var ingredientsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> liquids = new Queue<int>(liquidsInput);
            Stack<int> ingredients = new Stack<int>(ingredientsInput);
            var bread = 0;
            var cake = 0;
            var pastry = 0;
            var fruitPie = 0;
            while (liquids.Count != 0 && ingredients.Count != 0)
            {
                var calc = liquids.Peek() + ingredients.Peek();
                if (calc == 25)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    bread++;
                }
                else if (calc == 50)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    cake++;
                }
                else if (calc == 75)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    pastry++;
                }
                else if (calc == 100)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    fruitPie++;
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }
            if (bread > 0 && cake > 0 && pastry > 0 && fruitPie > 0)
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Count > 0)
            {
                Console.Write($"Liquids left: ");
                Console.Write(string.Join(", ", liquids));
            Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Liquids left: none");
            }
            if (ingredients.Count > 0)
            {
                Console.Write($"Ingredients left: ");
                Console.Write(string.Join(", ",ingredients));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Ingredients left: none");
            }
            Console.WriteLine($"Bread: {bread}\nCake: {cake}\nFruit Pie: {fruitPie}\nPastry: {pastry}");
        }
    }
}
