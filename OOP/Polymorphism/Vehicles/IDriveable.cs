using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IDriveable
    {
        public double TankCapacity { get;}
        public double FuelQuantity { get;}
        public double FuelConsumptionPerKm { get;}
        public string Drive(double distance);
        public void Refuel(double quantity);
    }
}
