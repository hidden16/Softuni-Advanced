using System;
using System.Collections.Generic;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            var stackSaver = new Stack<int>();
            var minElement = int.MaxValue;
            var maxElement = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "1")
                {
                    var toPush = int.Parse(commands[1]);
                    stack.Push(toPush);
                }
                else if (commands[0] == "2")
                {
                    stack.Pop();
                }
                else if (commands[0] == "3")
                {
                    stackSaver = new Stack<int>(stack);
                    while (stack.Count > 0)
                    {
                        var numSaver = stack.Peek();
                        if (stack.Pop() > maxElement)
                        {
                            maxElement = numSaver;
                        }
                    }
                    if (stackSaver.Count > 0)
                    {
                        Console.WriteLine(maxElement);
                    }
                    stack = new Stack<int>(stackSaver);
                }
                else if (commands[0] == "4")
                {
                    stackSaver = new Stack<int>(stack);
                    while (stack.Count > 0)
                    {
                        var numSaver = stack.Peek();
                        if (stack.Pop() < minElement)
                        {
                            minElement = numSaver;
                        }
                    }
                    if (stackSaver.Count > 0)
                    {
                        Console.WriteLine(minElement);
                    }
                    stack = new Stack<int>(stackSaver);
                }
            }
            List<int> output = new List<int>();
            while (stack.Count > 0)
            {
                output.Add(stack.Pop());
            }
            Console.WriteLine(string.Join(", ",output));
        }
    }
}
