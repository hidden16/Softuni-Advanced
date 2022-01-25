using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractBytesFromBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryFilePath = @"..\..\..\example.png";
            var bytesFilePath = @"..\..\..\bytes.txt";
            var outputPath = @"..\..\..\output.txt";
            ExtractBytes.ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }
    }
    public class ExtractBytes
    {
        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (StreamReader reader = new StreamReader(bytesFilePath))
            {
                byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
                var bytesList = new List<string>();
                var line = reader.ReadLine();
                var sb = new StringBuilder();
                while (line != null)
                {
                    bytesList.Add(line);
                    line = reader.ReadLine();
                }
                foreach (var item in bytesList)
                {
                    if (bytesList.Contains(item))
                    {
                        sb.AppendLine(item);
                    }
                }
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.Write(sb.ToString().Trim());
                }
            }
        }
    }

}
