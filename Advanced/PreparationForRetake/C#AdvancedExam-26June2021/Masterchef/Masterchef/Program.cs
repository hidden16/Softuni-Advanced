using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numberOfIngredients = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var freshnessLevel = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> ingredients = new Queue<int>(numberOfIngredients);
            Stack<int> freshness = new Stack<int>(freshnessLevel);

            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                {"Dipping sauce",0},
                {"Green salad",0},
                {"Chocolate cake",0},
                {"Lobster",0},
            };

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                var sum = freshness.Peek() * ingredients.Peek();

                if (sum == 150)
                {
                    dishes["Dipping sauce"]++;
                    freshness.Pop();
                    ingredients.Dequeue();
                }
                else if (sum == 250)
                {
                    dishes["Green salad"]++;
                    freshness.Pop();
                    ingredients.Dequeue();
                }
                else if (sum == 300)
                {
                    dishes["Chocolate cake"]++;
                    freshness.Pop();
                    ingredients.Dequeue();
                }
                else if (sum == 400)
                {
                    dishes["Lobster"]++;
                    freshness.Pop();
                    ingredients.Dequeue();
                }
                else
                {
                    freshness.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }

            if (dishes.All(x => x.Value > 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach (var item in dishes.Where(x=>x.Value>0).OrderBy(x=>x.Key))
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }
}
