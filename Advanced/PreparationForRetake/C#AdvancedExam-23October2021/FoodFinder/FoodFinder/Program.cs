using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<char> set = new HashSet<char>();
            var firstWords = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            var secondWords = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            foreach (var item in firstWords)
            {
                set.Add(item);
            }
            foreach (var item in secondWords)
            {
                set.Add(item);
            }

            Dictionary<string, int> words = new Dictionary<string, int>()
            {
                {"pear", 0},
                {"flour", 0},
                {"pork", 0},
                {"olive", 0}
            };
            List<string> foundWords = new List<string>();
            foreach (var word in words)
            {
                var charFound = 0;
                foreach (var character in set)
                {
                    if (word.Key.Contains(character))
                    {
                        charFound++;
                    }
                    if (charFound == word.Key.Length)
                    {
                        foundWords.Add(word.Key);
                        break;
                    }
                }
            }

            Console.WriteLine($"Words found: {foundWords.Count}");
            foreach (var item in foundWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
