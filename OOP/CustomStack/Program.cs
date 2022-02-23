using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            string[] strings = Console.ReadLine().Split();
            stack.AddRange(strings);
            while (stack.Count!= 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
