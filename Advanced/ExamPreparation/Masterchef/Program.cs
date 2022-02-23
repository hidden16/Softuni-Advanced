using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            const int dippingSauce = 150;
            const int greenSalad = 250;
            const int chocolateCake = 300;
            const int lobster = 400;
            Dictionary<string, int> dishes = new Dictionary<string, int>
            {
                {"Dipping sauce", 0 },
                {"Green salad", 0 },
                {"Chocolate cake", 0 },
                {"Lobster", 0 }
            };
            var ingredientsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var freshnessInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> ingredients = new Queue<int>(ingredientsInput);
            Stack<int> freshness = new Stack<int>(freshnessInput);
            Dishmaker(dippingSauce, greenSalad, chocolateCake, lobster, dishes, ingredients, freshness);
        }
        public static void Dishmaker(int dippingSauce, int greenSalad, int chocolateCake, int lobster, Dictionary<string, int> dishes, Queue<int> ingredients, Stack<int> freshness)
        {
            while (ingredients.Count != 0 && freshness.Count != 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                if (ingredients.Peek() * freshness.Peek() == dippingSauce)
                {
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (ingredients.Peek() * freshness.Peek() == greenSalad)
                {
                    dishes["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (ingredients.Peek() * freshness.Peek() == chocolateCake)
                {
                    dishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (ingredients.Peek() * freshness.Peek() == lobster)
                {
                    dishes["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }
            }
            if (dishes.All(x => x.Value > 0))
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
                if (ingredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                foreach (var dish in dishes.Where(x => x.Value > 0).OrderBy(x => x.Key))
                {
                    Console.WriteLine($"# {dish.Key} --> {dish.Value}");
                }
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (ingredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                foreach (var dish in dishes.Where(x => x.Value > 0).OrderBy(x => x.Key))
                {
                    Console.WriteLine($"# {dish.Key} --> {dish.Value}");
                }

            }
        }
    }
}
