using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : IDriveable
    {
        private double fuelQuantity;
        public Bus(double tankCapacity, double fuelConsumptionPerKm, double fuelQuantity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }
        public double FuelConsumptionPerKm { get; private set; }
        public double TankCapacity { get; private set; }



        public string Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumptionPerKm) > 0)
            {
                FuelQuantity -= distance * (FuelConsumptionPerKm + 1.4);
                return $"{GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{GetType().Name} needs refueling";
            }
        }
        public string DriveEmpty(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumptionPerKm) > 0)
            {
                FuelQuantity -= distance * FuelConsumptionPerKm;
                return $"{GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{GetType().Name} needs refueling";
            }
        }

        public void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQuantity + quantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
            }
            else
            {
                FuelQuantity += quantity;
            }
        }
    }
}
