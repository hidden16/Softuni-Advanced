using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {

        public SkiRental(string name, int capacity)
        {
            Data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }
        public List<Ski> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return Data.Count; }
        }
        public void Add(Ski ski)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski currSki = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (currSki != null)
            {
                Data.Remove(currSki);
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            if (Data.Count == 0)
            {
                return null;
            }
            return Data.OrderByDescending(x => x.Year).First();
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski currSki = Data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
            if (currSki != null)
            {
                return currSki;
            }
            return null;
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in Data)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
