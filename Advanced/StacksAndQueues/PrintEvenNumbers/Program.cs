using System;
using System.Collections.Generic;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<int> queue = new Queue<int>();
            List<int> output = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                queue.Enqueue(int.Parse(numbers[i]));
            }
            while (queue.Count != 0)
            {
                var currNum = queue.Peek();
                if (currNum % 2 == 1)
                {
                    queue.Dequeue();
                }
                else if (currNum % 2 == 0)
                {
                    output.Add(queue.Dequeue());
                }
            }
            Console.WriteLine(string.Join(", ", output));
        }
    }
}
