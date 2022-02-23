using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bombEffectsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var bombCasingInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> bombEffects = new Queue<int>(bombEffectsInput);
            Stack<int> bombCasings = new Stack<int>(bombCasingInput);
            var daturaBomb = 0;
            var cherryBomb = 0;
            var smokeDecoyBomb = 0;
            while (bombEffects.Count != 0 && bombCasings.Count != 0)
            {
                var sum = bombEffects.Peek() + bombCasings.Peek();
                if (sum == 40)
                {
                    daturaBomb++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 60)
                {
                    cherryBomb++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (sum == 120)
                {
                    smokeDecoyBomb++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    bombCasings.Push(bombCasings.Pop() - 5);
                }
                if (daturaBomb >= 3 && cherryBomb >= 3 && smokeDecoyBomb >= 3)
                {
                    break;
                }
            }
            if (daturaBomb >= 3 && cherryBomb >= 3 && smokeDecoyBomb >= 3)
            {
                Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",bombEffects)}");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: empty");
            }
            if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: empty");
            }
            Console.WriteLine($"Cherry Bombs: {cherryBomb}\nDatura Bombs: {daturaBomb}\nSmoke Decoy Bombs: {smokeDecoyBomb}");
        }
    }
}
