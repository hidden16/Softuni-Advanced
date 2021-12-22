using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensionNum = int.Parse(Console.ReadLine());
            string[,] matrix = new string[dimensionNum, dimensionNum];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = input[k].ToString();
                }
            }
            var symbolCheck = Console.ReadLine();
            bool isFalse = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == symbolCheck)
                    {
                        isFalse = true;
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }
            if (isFalse == false)
            {
                Console.WriteLine($"{symbolCheck} does not occur in the matrix");
            }
            
        }
    }
}
