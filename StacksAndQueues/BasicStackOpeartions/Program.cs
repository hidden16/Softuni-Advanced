using System;
using System.Collections.Generic;

namespace BasicStackOpeartions
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(input[0]);
            int numToPop = int.Parse(input[1]);
            int toLook = int.Parse(input[2]);
            var elements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < elements.Length; i++)
            {
                st.Push(int.Parse(elements[i]));
            }
            for (int i = 0; i < numToPop; i++)
            {
                st.Pop();
            }
            if (st.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (st.Contains(toLook))
            {
                Console.WriteLine($"true");
                return;
            }
            else
            {
                int lowest = int.MaxValue;
                foreach (var item in st)
                {
                    if (item < lowest)
                    {
                        lowest = item;
                    }
                }
                Console.WriteLine(lowest);
            }
        }
    }
}
