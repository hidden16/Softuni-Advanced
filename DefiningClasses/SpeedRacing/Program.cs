using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> car = new List<Car>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var fuelConsumptionFor1km = double.Parse(input[2]);
                if (fuelAmount >= 0 && fuelConsumptionFor1km >= 0)
                {
                    car.Add(new Car() { Model = model, FuelAmount = fuelAmount, FuelConsumptionPerKilometer = fuelConsumptionFor1km, TravelledDistance = 0 });
                }
            }
            var commands = Console.ReadLine();
            while (commands != "End")
            {
                var tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Drive")
                {
                    var carModel = tokens[1];
                    var amountofKm = int.Parse(tokens[2]);
                    for (int i = 0; i < car.Count; i++)
                    {
                        if (car[i].Model == carModel && amountofKm >= 0)
                        {
                            car[i].Drive(amountofKm);
                        }
                    }
                }
                commands = Console.ReadLine();
            }
            foreach (var item in car)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.TravelledDistance}");
            }
        }
    }
}
