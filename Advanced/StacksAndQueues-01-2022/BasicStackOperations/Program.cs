using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> st = new Stack<int>();
            var toPush = input[0];
            var toPop = input[1];
            var toLookFor = input[2];

            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            st = new Stack<int>(numbers);
            for (int i = 0; i < toPop; i++)
            {
                st.Pop();
            }
            if (st.Contains(toLookFor))
            {
                Console.WriteLine($"true");
            }
            else
            {
                if (st.Count > 0)
                {
                    Console.WriteLine($"{st.Pop()}");
                }
                else
                {
                    Console.WriteLine('0');
                }
            }
        }
    }
}
