using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(clothes);
            var rackCap = int.Parse(Console.ReadLine());
            var rackCounter = 1;
            var sum = 0;
            while (stack.Count>0)
            {
                if (stack.Peek() + sum <= rackCap)
                {
                    sum += stack.Pop();
                }
                else
                {
                    rackCounter++;
                    sum = 0;
                }
            }
            Console.WriteLine(rackCounter);
        }
    }
}
