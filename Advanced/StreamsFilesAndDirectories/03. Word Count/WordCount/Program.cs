using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        public static void Main(string[] args)
        {
            var wordsFilePath = @"..\..\..\words.txt";
            var textFilePath = @"..\..\..\text.txt";
            var outputFilePath = @"..\..\..\output.txt";
            WordCount.CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);
        }
    }
    public class WordCount
    {
        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            var wordsCheck = File.ReadAllText(wordsFilePath).Split();
            foreach (var word in wordsCheck)
            {
                if (!words.ContainsKey(word))
                {
                    words.Add(word, 0);
                }
            }
            using (StreamReader reader = new StreamReader(textFilePath))
            {
                var line = reader.ReadLine().ToLower();
                while (line != null)
                {
                    var splittedLine = line.Split(new char[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in wordsCheck)
                    {
                        foreach (var split in splittedLine)
                        {
                            if (word == split)
                            {
                                words[word]++;
                            }
                        }
                    }
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        line = line.ToLower();
                    }
                }
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var word in words.OrderByDescending(x=>x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }

}
