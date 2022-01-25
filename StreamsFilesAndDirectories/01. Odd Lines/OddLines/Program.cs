using System;
using System.IO;
using System.Text;

namespace OddLines
{
    public class OddLines
    {
        public static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            int index = 0;
            using (StreamReader reader = new StreamReader(@"..\..\..\Files\input.txt"))
            {
                using (StreamWriter stream = new StreamWriter(@"..\..\..\Files\output.txt"))
                {

                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (index % 2 == 1)
                        {
                            stream.WriteLine(line);
                        }
                        index++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}

