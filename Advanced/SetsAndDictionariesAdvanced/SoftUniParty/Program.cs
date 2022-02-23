using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> reservations = new Dictionary<string, HashSet<string>>();
            reservations.Add("vip", new HashSet<string>());
            reservations.Add("regular", new HashSet<string>());
            char[] vip = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var commands = Console.ReadLine();
            while (commands != "END")
            {
                if (commands == "PARTY")
                {
                    var input = Console.ReadLine();
                    while (input != "END")
                    {
                        if (reservations["vip"].Contains(input))
                        {
                            reservations["vip"].Remove(input);
                        }
                        if (reservations["regular"].Contains(input))
                        {
                            reservations["regular"].Remove(input);
                        }
                        input = Console.ReadLine();
                    }
                    break;
                }
                if (vip.Contains(commands[0]))
                {
                    reservations["vip"].Add(commands);
                }
                else
                {
                    reservations["regular"].Add(commands);
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine(reservations["vip"].Count + reservations["regular"].Count);
            foreach (var reservation in reservations)
            {
                foreach (var item in reservation.Value)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
