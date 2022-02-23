using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> st = new Stack<string>();
            foreach (var item in input)
            {
                st.Push(item);
            }
            Stack<string> rev = new Stack<string>();
            foreach (var item in st)
            {
                rev.Push(item);
            }
            while (rev.Count > 1)
            {
                var first = int.Parse(rev.Pop());
                var delimeter = rev.Pop();
                var second = int.Parse(rev.Pop());
                if (delimeter == "+")
                {
                    rev.Push($"{first + second}");
                }
                else if (delimeter == "-")
                {
                    rev.Push($"{first - second}");
                }
            }
            Console.WriteLine(rev.Pop());
        }
    }
}
