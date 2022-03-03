using System;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ");
            Smartphone smartphone = new Smartphone();
            ITelephone stationary = new StationaryPhone();
            foreach (var number in numbers)
            {
                if (number.Length == 10)
                {
                    Console.WriteLine(smartphone.Call(number));
                }
                else if (number.Length == 7)
                {
                    Console.WriteLine(stationary.Call(number));
                }
                else
                {
                    Console.WriteLine($"Invalid number!");
                }
            }
            var urls = Console.ReadLine().Split(" ");
            foreach (var url in urls)
            {
                Console.WriteLine(smartphone.Browse(url));
            }
        }
    }
}
