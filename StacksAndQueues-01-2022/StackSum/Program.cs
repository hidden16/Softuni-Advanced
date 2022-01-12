using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> st = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var commands = Console.ReadLine().ToLower();
            while (commands != "end")
            {
                var tokens = commands.Split();
                if (tokens[0] == "add")
                {
                    var numOne = int.Parse(tokens[1]);
                    var numTwo = int.Parse(tokens[2]);
                    st.Push(numOne);
                    st.Push(numTwo);
                }
                else if (tokens[0] == "remove")
                {
                    for (int i = 0; i < int.Parse(tokens[1]); i++)
                    {
                        if (int.Parse(tokens[1]) > st.Count)
                        {
                            break;
                        }
                        else
                        {
                            st.Pop();
                        }
                    }
                }
                commands = Console.ReadLine().ToLower();
            }
            var sum = 0;
            while (st.Count > 0)
            {
                sum += st.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
