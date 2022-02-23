using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<int> st = new Stack<int>();
            foreach (var item in input)
            {
                st.Push(int.Parse(item));
            }
            var sumStack = 0;
            while (true)
            {
                var cmd = Console.ReadLine();//End
                var splt = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                splt[0] = splt[0].ToLower();
                if (splt[0] == "end")
                {
                    foreach (var item in st)
                    {
                        sumStack += item;
                    }
                    Console.WriteLine($"Sum: {sumStack}");
                    return;

                }

                if (splt[0] == "add")
                {
                    var numOne = int.Parse(splt[1]);
                    var numTwo = int.Parse(splt[2]);
                    st.Push(numOne);
                    st.Push(numTwo);
                }
                else if (splt[0] == "remove")
                {
                    var count = int.Parse(splt[1]);
                    if (st.Count > count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            st.Pop();
                        }
                    }
                }
            }

        }
    }
}
