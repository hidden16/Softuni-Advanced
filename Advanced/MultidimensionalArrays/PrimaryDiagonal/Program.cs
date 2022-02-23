using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensionNum = int.Parse(Console.ReadLine());
            int[,] matrix = new int[dimensionNum, dimensionNum];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            int k = 0;
            var sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = k; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                    break;
                }
                k++;
            }
            Console.WriteLine(sum);
        }
    }
}
