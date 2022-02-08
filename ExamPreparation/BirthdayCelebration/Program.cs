using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            var guestsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var platesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> guests = new Queue<int>(guestsInput);
            Stack<int> plates = new Stack<int>(platesInput);
            var wastedFood = 0;
            while (guests.Count > 0 && plates.Count > 0)
            {
                var currGuest = guests.Peek();
                currGuest -= plates.Pop();
                if (currGuest <= 0)
                {
                    wastedFood += Math.Abs(currGuest);
                    guests.Dequeue();
                }
                else
                {
                    while (currGuest > 0 && plates.Count > 0)
                    {
                        currGuest -= plates.Pop();
                    }
                    guests.Dequeue();
                    wastedFood += Math.Abs(currGuest);
                }
            }
            if (guests.Count > 0)
            {
                Console.Write($"Guests: ");
                Console.Write(string.Join(" ", guests));
            }
            else if (plates.Count > 0)
            {
                Console.Write("Plates: ");
                Console.Write(string.Join(" ", plates));
            }
            Console.WriteLine();
            Console.WriteLine("Wasted grams of food: " + wastedFood);
        }
    }
}
