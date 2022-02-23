using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var steelInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var carbonInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> steel = new Queue<int>(steelInput);
            Stack<int> carbon = new Stack<int>(carbonInput);
            Dictionary<string, int> swords = new Dictionary<string, int>()
            {
                {"Gladius", 0 },
                {"Shamshir", 0 },
                {"Katana", 0 },
                {"Sabre", 0 },
                {"Broadsword", 0 }
            };
            var swordCounter = 0;
            while (steel.Count != 0 && carbon.Count != 0)
            {
                var sum = steel.Peek() + carbon.Peek();
                if (sum == 70)
                {
                    swords["Gladius"]++;
                    swordCounter++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 80)
                {
                    swords["Shamshir"]++;
                    swordCounter++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 90)
                {
                    swords["Katana"]++;
                    swordCounter++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 110)
                {
                    swords["Sabre"]++;
                    swordCounter++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (sum == 150)
                {
                    swords["Broadsword"]++;
                    swordCounter++; ;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    carbon.Push(carbon.Pop() + 5);
                }
            }
            bool isTrue = true;
            if (swords.Values.Any(x=>x > 0))
            {
                Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
                isTrue = false;
            }
            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine($"Steel left: none");
            }
            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine($"Carbon left: none");
            }
            if (isTrue)
            {
                foreach (var sword in swords.Where(x=>x.Value > 0).OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
            
        }
    }
}
