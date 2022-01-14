using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceOfBullet = int.Parse(Console.ReadLine());
            var magazineCapacity = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var safeValue = int.Parse(Console.ReadLine());
            var bulletsLeft = magazineCapacity;
            var bulletsCount = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                var bullet = bullets.Pop();
                var currentLock = locks.Peek();
                bulletsLeft--;
                bulletsCount++;
                if (bullet <= currentLock)
                {
                    Console.WriteLine($"Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Ping!");
                }
                if (bulletsLeft == 0 && bullets.Count > 0)
                {
                    Console.WriteLine($"Reloading!");
                    bulletsLeft = magazineCapacity;
                }
            }
            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                safeValue -= (bulletsCount * priceOfBullet);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${safeValue}");
            }
        }
    }
}
