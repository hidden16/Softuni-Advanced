using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Data = new List<Pet>();
            Capacity = capacity;
        }
        public List<Pet> Data { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;
        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                Data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            var currPet = Data.Find(x => x.Name == name);
            if (currPet != null)
            {
                Data.Remove(currPet);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            var currPet = Data.Find(x=>x.Name == name && x.Owner == owner);
            if (currPet != null)
            {
                return currPet;
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            var oldestPet = Data.OrderByDescending(x => x.Age).First();
            return oldestPet;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");
            foreach (var item in Data)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
