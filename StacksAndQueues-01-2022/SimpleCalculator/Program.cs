using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }
            Stack<string> reversedStack = new Stack<string>();
            while (stack.Count > 0)
            {
                reversedStack.Push(stack.Pop());
            }
            var sum = 0;
            while (reversedStack.Count > 1)
            {
                if (int.Parse(reversedStack.Peek()) >= 0)
                {
                    sum = int.Parse(reversedStack.Pop());
                    if (reversedStack.Peek() == "+")
                    {
                        reversedStack.Pop();
                        sum += int.Parse(reversedStack.Pop());
                    }
                    else if (reversedStack.Peek() == "-")
                    {
                        reversedStack.Pop();
                        sum -= int.Parse(reversedStack.Pop());
                    }
                    reversedStack.Push(sum.ToString());
                }
            }
            Console.WriteLine(reversedStack.Pop()); ;
        }
    }
}
