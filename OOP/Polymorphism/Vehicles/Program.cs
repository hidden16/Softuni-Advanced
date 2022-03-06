using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDriveable car = null;
            IDriveable truck = null;
            IDriveable bus = null;
            for (int i = 0; i < 3; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var type = input[0];
                var fuelQty = double.Parse(input[1]);
                var litersPerKm = double.Parse(input[2]);
                var tankCapacity = double.Parse(input[3]);
                if (type == "Car")
                {
                    car = new Car(tankCapacity, litersPerKm, fuelQty);
                }
                else if (type == "Truck")
                {
                    truck = new Truck(tankCapacity, litersPerKm, fuelQty);
                }
                else if (type == "Bus")
                {
                    bus = new Bus(tankCapacity, litersPerKm, fuelQty);
                }
            }
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
                    else if (commands[1] == "Bus")
                    {
                        Console.WriteLine(bus.Drive(double.Parse(commands[2])));
                    }
                }
                else if (commands[0] == "DriveEmpty")
                {
                    Console.WriteLine(((Bus)bus).DriveEmpty(double.Parse(commands[2])));
                }
                else if (commands[0] == "Refuel")
                {
                    if (commands[1] == "Car")
                    {
                        car.Refuel(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(commands[2]));
                    }
                }
            }
            Console.WriteLine($"{car.GetType().Name}: {car.FuelQuantity:f2}");
            Console.WriteLine($"{truck.GetType().Name}: {truck.FuelQuantity:f2}");
            Console.WriteLine($"{bus.GetType().Name}: {bus.FuelQuantity:f2}");
        }
    }
}
