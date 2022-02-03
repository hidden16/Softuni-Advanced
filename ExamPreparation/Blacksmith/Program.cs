using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Gladius = 70;
            const int Shamshir = 80;
            const int Katana = 90;
            const int Sabre = 110;
            const int Broadsword = 150;
            Dictionary<string, int> madeSwordsNames = new Dictionary<string, int>();
            madeSwordsNames.Add("Gladius", 0);
            madeSwordsNames.Add("Shamshir", 0);
            madeSwordsNames.Add("Katana", 0);
            madeSwordsNames.Add("Sabre", 0);
            madeSwordsNames.Add("Broadsword", 0);

            var steelInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var carbonInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> steel = new Queue<int>(steelInput);
            Stack<int> carbon = new Stack<int>(carbonInput);
            var swordCounter = 0;
            while (steel.Count > 0 && carbon.Count > 0)
            {
                switch (steel.Peek() + carbon.Peek())
                {
                    case Gladius:
                        madeSwordsNames["Gladius"]++;
                        swordCounter++;
                        steel.Dequeue();
                        carbon.Pop();
                        break;
                    case Shamshir:
                        madeSwordsNames["Shamshir"]++;
                        swordCounter++;
                        steel.Dequeue();
                        carbon.Pop();
                        break;
                    case Katana:
                        madeSwordsNames["Katana"]++;
                        swordCounter++;
                        steel.Dequeue();
                        carbon.Pop();
                        break;
                    case Sabre:
                        madeSwordsNames["Sabre"]++;
                        swordCounter++;
                        steel.Dequeue();
                        carbon.Pop();
                        break;
                    case Broadsword:
                        madeSwordsNames["Broadsword"]++;
                        swordCounter++;
                        steel.Dequeue();
                        carbon.Pop();
                        break;
                    default:
                        steel.Dequeue();
                        carbon.Push(carbon.Pop() + 5);
                        break;
                }
            }
            bool isTrue = true;
            if (swordCounter != 0)
            {
                Console.WriteLine($"You have forged {swordCounter} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
                isTrue = false;
            }
            if (steel.Count != 0)
            {
                Console.Write($"Steel left: ");
                var counter = 0;
                while (steel.Count != 0)
                {
                    if (counter < steel.Count)
                    {
                        Console.Write($"{steel.Dequeue()}, ");
                    }
                    else
                    {
                        Console.Write($"{steel.Dequeue()}");
                    }
                    counter++;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Steel left: none");
            }
            if (carbon.Count != 0)
            {
                Console.Write($"Carbon left: ");
                var counter = 0;
                while (carbon.Count != 0)
                {
                    if (counter < carbon.Count)
                    {
                        Console.Write($"{carbon.Pop()}, ");
                    }
                    else
                    {
                        Console.Write($"{carbon.Pop()}");
                    }
                    counter++;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Carbon left: none");
            }
            if (isTrue)
            {
                foreach (var sword in madeSwordsNames.OrderBy(x => x.Key).Where(x=>x.Value > 0))
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
