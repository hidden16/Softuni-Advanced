using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : IDriveable
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm + 1.6;
        }
        public double FuelQuantity { get; private set; }
        public double FuelConsumptionPerKm { get; private set; }

        public string Drive(double distance)
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
            FuelQuantity += quantity - (quantity * 0.05);
        }
    }
}
