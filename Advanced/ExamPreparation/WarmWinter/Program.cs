using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> hats = new Stack<int>(input1);
            Queue<int> scarfs = new Queue<int>(input2);
            List<int> set = new List<int>();
            while (hats.Count != 0 && scarfs.Count != 0)
            {
                if (hats.Peek() > scarfs.Peek())
                {
                    var calc = hats.Pop() + scarfs.Dequeue();
                    set.Add(calc);
                }
                else if (hats.Peek() < scarfs.Peek())
                {
                    hats.Pop();
                    continue;
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }
            var maxSet = set.OrderByDescending(x => x).First();
            Console.WriteLine($"The most expensive set is: {maxSet}");
            Console.WriteLine(String.Join(" ", set));
        }
    }
}
