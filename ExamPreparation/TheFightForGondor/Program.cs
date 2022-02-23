using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            var input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> plates = new Queue<int>(input1);
            Stack<int> orcs = new Stack<int>();
            var orcWin = false;
            for (int i = 1; i <= waves; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                orcs = new Stack<int>(input);
                if (i % 3 == 0)
                {
                    var plateAdd = int.Parse(Console.ReadLine());
                    plates.Enqueue(plateAdd);
                }
                while (orcs.Count != 0 && plates.Count != 0)
                {
                    if (orcs.Peek() > plates.Peek())
                    {
                        orcs.Push(orcs.Pop() - plates.Dequeue());
                    }
                    else if (orcs.Peek() < plates.Peek())
                    {
                        plates.Enqueue(plates.Dequeue() - orcs.Pop());
                        for (int j = 0; j < plates.Count - 1; j++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }
                    }
                    else if (orcs.Peek() == plates.Peek())
                    {
                        orcs.Pop();
                        plates.Dequeue();
                    }
                }
                if (plates.Count == 0)
                {
                    orcWin = true;
                    break;
                }
            }
            if (orcWin)
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
            }
            if (orcs.Count > 0)
            {
                Console.Write($"Orcs left: ");
                Console.Write(string.Join(", ", orcs));
            }
            if (plates.Count > 0)
            {
                Console.Write($"Plates left: ");
                Console.Write(string.Join(", ", plates));
            }
        }
    }
}
