using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MergeFiles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\input1.txt";
            var secondInputFilePath = @"..\..\..\input2.txt";
            var outputInputFilePath = @"..\..\..\output.txt";
            MergeFiles.MergeTextFiles(firstInputFilePath, secondInputFilePath, outputInputFilePath);
        }
    }
    public class MergeFiles
    {
        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<int> readersMerged = new List<int>();
            using (StreamReader reader1 = new StreamReader(firstInputFilePath))
            {
                var line = reader1.ReadLine();
                while (line != null)
                {
                    readersMerged.Add(int.Parse(line));
                    line = reader1.ReadLine();
                }
                using (StreamReader reader2 = new StreamReader(secondInputFilePath))
                {
                    var line2 = reader2.ReadLine();
                    while (line2 != null)
                    {
                        readersMerged.Add(int.Parse(line2));
                        line2 = reader2.ReadLine();
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var item in readersMerged.OrderBy(x=>x))
                {
                    writer.WriteLine(item);
                }
            }
        }
    }

}
