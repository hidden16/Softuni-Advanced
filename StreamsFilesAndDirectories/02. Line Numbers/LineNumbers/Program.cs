using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var index = 1;
            using (StreamReader reader = new StreamReader(@"..\..\..\Files\input.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\..\Files\output.txt"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine(index + ". " + line, 0, 1);
                        index++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }

}
