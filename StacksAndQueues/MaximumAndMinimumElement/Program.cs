using System;
using System.Collections.Generic;
using System.Linq;
namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "1")
                {
                    var toPush = commands[1];
                    stack.Push(toPush);
                }
                else if (commands[0] == "2")
                {
                    if (stack.Count == 0)
                    {

                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else if (commands[0] == "3")
                {
                    var biggest = int.MinValue;
                    foreach (var item in stack)
                    {
                        if (int.Parse(item) > biggest)
                        {
                            biggest = int.Parse(item);
                        }
                    }
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(biggest);
                    }
                }
                else if (commands[0] == "4")
                {
                    var lowest = int.MaxValue;
                    foreach (var item in stack)
                    {
                        if (int.Parse(item) < lowest)
                        {
                            lowest = int.Parse(item);
                        }
                    }
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(lowest);
                    }
                }
            }
            List<string> list = new List<string>();
            foreach (var item in stack)
            {
                list.Add(item);
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
