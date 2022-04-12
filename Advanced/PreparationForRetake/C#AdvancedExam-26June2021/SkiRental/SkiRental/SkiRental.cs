using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public List<Ski> Data => data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;
        public void Add(Ski ski)
        {
            if (Count < Capacity)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var currSki = data.FirstOrDefault(x=>x.Manufacturer == manufacturer && x.Model == model);
            if (currSki != null)
            {
                data.Remove(currSki);
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            // check for problems
            var currSki = data.OrderByDescending(x => x.Year).FirstOrDefault();
            return currSki;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            var currSki = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return currSki;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in Data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
