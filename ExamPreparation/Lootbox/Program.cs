using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> loot1 = new Queue<int>(input1);
            Stack<int> loot2 = new Stack<int>(input2);
            List<int> claimedItems = new List<int>();
            while (loot1.Count != 0 && loot2.Count != 0)
            {
                var calc = loot1.Peek() + loot2.Peek();
                if (calc % 2 == 0)
                {
                    loot1.Dequeue();
                    loot2.Pop();
                    claimedItems.Add(calc);
                }
                else
                {
                    loot1.Enqueue(loot2.Pop());
                }
            }
            if (loot1.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (loot2.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
