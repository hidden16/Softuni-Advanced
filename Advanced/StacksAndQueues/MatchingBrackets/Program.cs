using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    st.Push(i);
                }
                else if (input[i] == ')')
                {
                    var index = st.Pop();
                    Console.WriteLine(input.Substring(index, i - index + 1));
                }
            }
        }
    }
}
