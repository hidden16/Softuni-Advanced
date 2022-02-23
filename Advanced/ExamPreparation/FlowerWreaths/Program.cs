using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rosesInput = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var liliesInput = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> lilies = new Stack<int>(liliesInput);
            Queue<int> roses = new Queue<int>(rosesInput);
            var wreaths = 0;
            var leftFlowers = 0;
            while (lilies.Count != 0 && roses.Count != 0)
            {
                if (lilies.Peek() + roses.Peek() == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else if (lilies.Peek() + roses.Peek() < 15)
                {
                    leftFlowers += lilies.Pop() + roses.Dequeue();
                }
            }
            if (leftFlowers / 15 > 0)
            {
                wreaths += leftFlowers / 15;
            }
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
