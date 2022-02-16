using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            Data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }
        public List<Racer> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;
        public void Add(Racer racer)
        {
            if (Count < Capacity)
            {
                Data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            var currRacer = Data.Find(x => x.Name == name);
            if (currRacer != null)
            {
                Data.Remove(currRacer);
                return true;
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            var oldestRacer = Data.OrderByDescending(x => x.Age).First();
            return oldestRacer;
        }
        public Racer GetRacer(string name)
        {
            var racer = Data.Find(x => x.Name == name);
            return racer;
        }
        public Racer GetFastestRacer()
        {
            var fastest = Data.OrderByDescending(x => x.Car.Speed).First();
            return fastest;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var item in Data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
