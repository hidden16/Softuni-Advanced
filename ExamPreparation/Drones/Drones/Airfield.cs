using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get {return Drones.Count; } }
        public string AddDrone(Drone drone)
        {
            if (drone.Name == null || drone.Name == string.Empty || drone.Brand == null || drone.Brand == string.Empty || drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
                
            }
            if (Drones.Count >= Capacity)
            {
                return "Airfield is full.";
            }
            Drones.Add(drone);
            return $"Succesfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Name == name)
                {
                    Drones.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            var counter = 0;
            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Brand == brand)
                {
                    Drones.RemoveAt(i);
                    counter++;
                    i--;
                }
            }
            return counter;
        }
        public Drone FlyDrone(string name)
        {
            foreach (var drone in Drones)
            {
                if (drone.Name == name)
                {
                    drone.Available = false;
                    return drone;
                }
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> fliedDrones = new List<Drone>();
            foreach (var drone in Drones)
            {
                if (drone.Range >= range)
                {
                    fliedDrones.Add(drone);
                    drone.Available = false;
                }
            }
            return fliedDrones;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}: ");
            foreach (var drone in Drones)
            {
                if (drone.Available == true)
                {
                    sb.AppendLine(drone.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
