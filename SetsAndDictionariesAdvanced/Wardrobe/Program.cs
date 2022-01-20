using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var color = input[0];
                var items = input[1];
                var itemSplitted = items.Split(",");
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    for (int j = 0; j < itemSplitted.Length; j++)
                    {
                        wardrobe[color].Add(itemSplitted[j], 1);
                    }
                }
                else
                {
                    for (int k = 0; k < itemSplitted.Length; k++)
                    {
                        if (!wardrobe[color].ContainsKey(itemSplitted[k]))
                        {
                            wardrobe[color].Add(itemSplitted[k], 1);
                        }
                        else
                        {
                            wardrobe[color][itemSplitted[k]]++;
                        }
                    }
                }
            }
            var toLookFor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
                foreach (var color in wardrobe)
                {
                    Console.WriteLine($"{color.Key} clothes:");
                    foreach (var dress in color.Value)
                    {
                        if (toLookFor[0] == color.Key && toLookFor[1] == dress.Key)
                        {
                            Console.WriteLine($"* {dress.Key} - {dress.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {dress.Key} - {dress.Value}");
                        }
                    }
                }
            
        }
    }
}
