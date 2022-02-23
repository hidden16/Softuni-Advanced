using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Data = new List<Car>();
            Type = type;
            Capacity = capacity;
        }
        public List<Car> Data { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;
        public void Add(Car car)
        {
            if (Count < Capacity)
            {
                Data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var currCar = Data.Find(x=>x.Manufacturer == manufacturer && x.Model == model);
            if (currCar != null)
            {
                Data.Remove(currCar);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if (Count == 0)
            {
                return null;
            }
            var currCar = Data.OrderByDescending(x => x.Year).First();
            return currCar;
        }
        public Car GetCar(string manufacturer, string model)
        {
            var currCar = Data.Find(x=>x.Manufacturer == manufacturer && x.Model == model);
            if (currCar != null)
            {
                return currCar;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var item in Data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
