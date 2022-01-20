using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();
            var commands = Console.ReadLine();
            while (commands != "END")
            {
                var splitted = commands.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (splitted[0] == "IN")
                {
                    carNumbers.Add(splitted[1]);
                }
                else
                {
                    if (carNumbers.Contains(splitted[1]))
                    {
                        carNumbers.Remove(splitted[1]);
                    }
                }
                commands = Console.ReadLine();
            }
            if (carNumbers.Count > 0)
            {
                foreach (var car in carNumbers)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
