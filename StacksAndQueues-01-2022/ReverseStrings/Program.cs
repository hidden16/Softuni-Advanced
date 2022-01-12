using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack<char> st = new Stack<char>();
            foreach (var item in input)
            {
                st.Push(item);
            }
            while (st.Count>0)
            {
                Console.Write(st.Pop());
            }
        }
    }
}
