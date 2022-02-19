using System;
using System.Collections.Generic;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vowelsInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var consonantsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> set = new HashSet<string>();
            foreach (var item in vowelsInput)
            {
                set.Add(item);
            }
            foreach (var consonant in consonantsInput)
            {
                set.Add(consonant);
            }
            string[] words = new string[4]
            {
               "rear",
               "flour",
               "pork",
               "olive"
            };
            List<string> foundWords = new List<string>();
            foreach (var word in words)
            {
                var count = 0;
                foreach (var item in set)
                {
                    if (word.Contains(item))
                    {
                        count++;
                    }
                    if (count == word.Length)
                    {
                        foundWords.Add(word);
                        break;
                    }
                }
            }
            Console.WriteLine($"Words found: {foundWords.Count}");
            foreach (var word in foundWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
