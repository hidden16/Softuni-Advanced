using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack<string> st = new Stack<string>();
            foreach (var item in input)
            {
                st.Push(item.ToString());
            }
            foreach (var item in st)
            {
                Console.Write(item);
            }
        }
    }
}
