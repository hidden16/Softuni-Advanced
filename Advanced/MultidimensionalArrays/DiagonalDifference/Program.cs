using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            var sumOne = 0;
            var sumTwo = 0;
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                sumOne += matrix[i, i];
            }
            int k = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                sumTwo += matrix[k, i];
                k++;
            }
            Console.WriteLine(Math.Abs(sumOne - sumTwo));
        }
    }
}
