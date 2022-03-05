using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var carFuelQty = double.Parse(carInput[1]);
            var litersPerKm = double.Parse(carInput[2]);
            IDriveable car = new Car(carFuelQty, litersPerKm);
            var truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var truckFuelQty = double.Parse(truckInput[1]);
            var truckLitersPerKm = double.Parse(truckInput[2]);
            IDriveable truck = new Truck(truckFuelQty, truckLitersPerKm);
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Drive")
                {
                    if (commands[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(commands[2])));
                    }
                    else if (commands[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(commands[2])));   
                    }
                }
                if (commands[0] == "Refuel")
                {
                    if (commands[1] == "Car")
                    {
                        car.Refuel(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(commands[2]));
                    }
                }
            }
            Console.WriteLine($"{car.GetType().Name}: {car.FuelQuantity:f2}");
            Console.WriteLine($"{truck.GetType().Name}: {truck.FuelQuantity:f2}");
        }
    }
}
