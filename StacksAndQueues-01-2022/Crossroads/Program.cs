using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            var input = Console.ReadLine();
            var passed = 0;
            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }
                var currentGreenLight = greenLight;
                while (currentGreenLight > 0 && cars.Count > 0)
                {
                    var currCar = cars.Dequeue();
                    if (currentGreenLight - currCar.Length >= 0)
                    {
                        currentGreenLight -= currCar.Length;
                        passed++;
                        continue;
                    }
                    if (currentGreenLight + freeWindow - currCar.Length >= 0)
                    {
                        currentGreenLight = 0;
                        passed++;
                        continue;
                    }
                    int hittedChar = currentGreenLight + freeWindow;
                    Console.WriteLine($"A crash happened!");
                    Console.WriteLine($"{currCar} was hit at {currCar[hittedChar]}.");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{passed} total cars passed the crossroads.");
        }
    }
}
