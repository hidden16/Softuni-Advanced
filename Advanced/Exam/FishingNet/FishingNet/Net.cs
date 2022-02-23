using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Fish = new List<Fish>();
            Material = material;
            Capacity = capacity;
        }

        public List<Fish> Fish { get; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => Fish.Count;
        public string AddFish(Fish fish)
        {
            if (Count >= Capacity)
            {
                return $"Fishing net is full.";
            }
            if ((!string.IsNullOrWhiteSpace(fish.FishType)) && fish.Length > 0 && fish.Weight > 0)
            {
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
            return $"Invalid fish.";
        }
        public bool ReleaseFish(double weight)
        {
            var currFish = Fish.Find(x=>x.Weight == weight);
            if (currFish != null)
            {
                Fish.Remove(currFish);
                return true;
            }
            return false;
        }
        public Fish GetFish(string fishType)
        {
            var currFish = Fish.FirstOrDefault(x=>x.FishType == fishType);
            if (currFish != null)
            {
                return currFish;
            }
            return null;
        }
        public Fish GetBiggestFish()
        {
            var currFish = Fish.OrderByDescending(x => x.Length).First();
            if (currFish != null)
            {
            return currFish;
            }
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var item in Fish.OrderByDescending(x=>x.Length))
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
