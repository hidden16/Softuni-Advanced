using System;
using System.Collections.Generic;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<int> stack = new Stack<int>();
            foreach (var item in input)
            {
                stack.Push(int.Parse(item));
            }
            var maxRack = int.Parse(Console.ReadLine());
            var rackCounter = 0;
            var sum = 0;
            while (stack.Count != 0)
            {
                if (sum + stack.Peek() < maxRack)
                {
                    sum += stack.Pop();
                }
                else if (sum + stack.Peek() == maxRack)
                {
                    stack.Pop();
                    rackCounter++;
                    sum = 0;
                }
                else if (sum + stack.Peek() > maxRack)
                {
                    rackCounter++;
                    sum = 0;
                }
            }
            if (sum > 0)
            {
                rackCounter++;
            }
            Console.WriteLine(rackCounter);
        }
    }
}
