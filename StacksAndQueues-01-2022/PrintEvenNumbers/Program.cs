using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> qu = new Queue<int>(input);
            List<int> evenNums = new List<int>();
            while (qu.Count > 0)
            {
                if (qu.Peek() % 2 == 0)
                {
                    evenNums.Add(qu.Dequeue());
                }
                else if (qu.Peek() % 2 == 1)
                {
                    qu.Dequeue();
                }
            }
            Console.WriteLine(string.Join(", ",evenNums));
        }
    }
}
