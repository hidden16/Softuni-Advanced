using System;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> market = new SortedDictionary<string, Dictionary<string, double>>();
            var commands = Console.ReadLine();
            while (commands != "Revision")
            {
                var splitted = commands.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                var shop = splitted[0];
                var product = splitted[1];
                var price = double.Parse(splitted[2]);
                if (!market.ContainsKey(shop))
                {
                    market.Add(shop, new Dictionary<string, double>());
                    market[shop].Add(product, price);
                }
                else
                {
                    if (!market[shop].ContainsKey(product))
                    {
                        market[shop].Add(product, price);
                    }
                }
                commands = Console.ReadLine();
            }
            foreach (var shop in market)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
