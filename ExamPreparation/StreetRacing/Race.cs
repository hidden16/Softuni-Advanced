using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }
        public List<Car> Participants = new List<Car>();
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count;
        public void Add(Car car)
        {
            if (Participants.All(x=>x.LicensePlate != car.LicensePlate) && Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            var currCar = Participants.Find(x=>x.LicensePlate == licensePlate);
            if (currCar != null)
            {
                Participants.Remove(currCar);
                return true;
            }
            return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            var currCar = Participants.Find(x => x.LicensePlate == licensePlate);
            if (currCar != null)
            {
                return currCar;
            }
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            if (Count == 0)
            {
                return null;
            }
            var currCar = Participants.OrderByDescending(x => x.HorsePower).First();
            return currCar;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var item in Participants)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
