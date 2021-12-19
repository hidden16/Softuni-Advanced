using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            char[] openingParentheses = new char[] {'[', '{', '('};
            bool isValid = true;
            foreach (var item in input)
            {
                if (openingParentheses.Contains(item))
                {
                    stack.Push(item);
                    continue;
                }
                if (stack.Count == 0)
                {
                    isValid = false;
                    break;
                }
                if (stack.Peek() == '[' && item == ']')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '{' && item == '}')
                {
                    stack.Pop();
                }
                else if (stack.Peek() == '(' && item == ')')
                {
                    stack.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
