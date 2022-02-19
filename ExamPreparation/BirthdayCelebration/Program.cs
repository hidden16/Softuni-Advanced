using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var guestsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var platesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> guests = new Queue<int>(guestsInput);
            Stack<int> plates = new Stack<int>(platesInput);
            var wastedFood = 0;
            while (guests.Count != 0 && plates.Count != 0)
            {
                if (plates.Peek() >= guests.Peek())
                {
                    wastedFood += plates.Pop() - guests.Dequeue();
                }
                else if (plates.Peek() < guests.Peek())
                {
                    var guest = guests.Peek();
                    while (guest > 0)
                    {
                        if (plates.Count > 0)
                        {
                            guest -= plates.Pop();
                        }
                        else
                        {
                            break;
                        }
                    }
                    guests.Dequeue();
                    wastedFood += Math.Abs(guest);
                }
            }
            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
