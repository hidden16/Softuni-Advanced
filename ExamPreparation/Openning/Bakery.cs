using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public Bakery(string name, int capacity)
        {
            Data = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }

        public List<Employee> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;
        public void Add(Employee employee)
        {
            if (Count < Capacity)
            {
                Data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            var currEmployee = Data.Find(x=>x.Name == name);
            if (currEmployee != null)
            {
                Data.Remove(currEmployee);
                return true;
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            var currEmployee = Data.OrderByDescending(x => x.Age).First();
            return currEmployee;
        }
        public Employee GetEmployee(string name)
        {
            var currEmployee = Data.Find(x => x.Name == name);
            if (currEmployee != null)
            {
                return currEmployee;
            }
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var item in Data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
