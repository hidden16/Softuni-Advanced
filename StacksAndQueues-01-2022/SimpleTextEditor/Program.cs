using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stb = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "1")
                {
                    stack.Push(stb.ToString());
                    stb.Append(input[1]);
                }
                else if (input[0] == "2")
                {
                    stack.Push(stb.ToString());
                    var toRemove = int.Parse(input[1]);
                    stb.Remove(stb.Length - toRemove, toRemove);
                }
                else if (input[0] == "3")
                {
                    var index = int.Parse(input[1]) - 1;
                    Console.WriteLine(stb[index]);
                }
                else if (input[0] == "4")
                {
                    stb.Clear();
                    stb.Append(stack.Pop());
                }
            }
        }
    }
}
