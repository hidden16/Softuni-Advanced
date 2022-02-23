using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        string model;
        double fuelAmount;
        double fuelConsumptionPerKilometer;
        double travelledDistance;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; } 
            set { fuelAmount = value; } 
        }
        public double FuelConsumptionPerKilometer 
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistance
        {
            get { return travelledDistance; } 
            set { travelledDistance = value; }
        }
        public void Drive(int amountOfKm)
        {
            if (FuelAmount - (FuelConsumptionPerKilometer * amountOfKm) >= 0)
            {
                FuelAmount -= FuelConsumptionPerKilometer * amountOfKm;
                TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

}
