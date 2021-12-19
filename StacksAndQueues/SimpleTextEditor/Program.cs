using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Stack<string> stack = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "1")
                {
                    stack.Push(text);
                    text += commands[1];
                }
                else if (commands[0] == "2")
                {
                    var count = int.Parse(commands[1]);
                    stack.Push(text);
                    text = text.Remove(text.Length - count, count);
                }
                else if (commands[0] == "3")
                {
                    var index = int.Parse(commands[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (commands[0] == "4")
                {
                    text = stack.Pop();
                }
            }
        }
    }
}
