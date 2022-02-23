using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public IReadOnlyCollection<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => Drones.Count;
        public string AddDrone(Drone drone)
        {
            if (Count >= Capacity)
            {
                return $"Airfield is full";
            }
            if (!(string.IsNullOrEmpty(drone.Name) && string.IsNullOrEmpty(drone.Brand)))
            {
                if (drone.Range >= 5 && drone.Range <= 15)
                {
                    Drones.Add(drone);
                    return $"Successfully added {drone.Name} to the airfield.";
                }
            }
            return $"Invalid drone.";
        }
        public bool RemoveDrone(string name)
        {
            var currDrone = Drones.Find(x => x.Name == name);
            if (currDrone != null)
            {
                Drones.Remove(currDrone);
                return true;
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            var removedCounter = 0;
            foreach (var item in Drones)
            {
                if (item.Brand == brand)
                {
                    removedCounter++;
                }
            }
            Drones.RemoveAll(x => x.Brand == brand);
            if (removedCounter > 0)
            {
                return removedCounter;
            }
            return 0;
        }
        public Drone FlyDrone(string name)
        {
            var currDrone = Drones.Find(x => x.Name == name);
            if (currDrone != null)
            {
                return Fly(currDrone);
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flownDrones = new List<Drone>();
            foreach (var item in Drones)
            {
                if (item.Range >= range)
                {
                    item.Available = false;
                    flownDrones.Add(item);
                }
            }
            return flownDrones;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var drone in Drones.Where(x => x.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        public Drone Fly(Drone drone)
        {
            drone.Available = false;
            return drone;
        }
    }
}
