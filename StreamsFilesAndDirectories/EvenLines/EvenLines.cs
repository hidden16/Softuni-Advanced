namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder outputSb = new StringBuilder();
                var index = 0;
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (index % 2 == 0)
                    {
                    sb.Append(line);
                        var text = ReplaceSymbols(sb.ToString());
                        sb.Clear();
                        sb.Append(text);
                        var reversed = ReverseWords(sb.ToString());
                        sb.Clear();
                        outputSb.AppendLine(reversed);
                    }
                    index++;
                    line = reader.ReadLine();
                }
                return outputSb.ToString();
            }
        }
        private static string ReverseWords(string sb)
        {
            var textToReverse = sb;
            var splitted = textToReverse.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            StringBuilder reversed = new StringBuilder();
            for (int i = splitted.Length - 1; i >= 0; i--)
            {
                reversed.Append(splitted[i] + " ");
            }

            return reversed.ToString();
        }

        private static string ReplaceSymbols(string sb)
        {
            char[] containers = new char[] { '-', ',', '.', '!', '?' };
            StringBuilder stb = new StringBuilder(sb);
            foreach (var letter in stb.ToString())
            {
                if (containers.Contains(letter))
                {
                    stb.Replace(letter, '@');
                }
            }
            sb = stb.ToString();
            return sb;

        }
    }

}
