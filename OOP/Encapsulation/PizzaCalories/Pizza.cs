using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        string name;
        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                try
                {
                    if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                    {
                        throw new Exception();
                    }
                    name = value;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(0);
                }
            }
        }
        public Dough Doughs { get; set; }
        public List<Topping> Toppings { get; set; }
        public int ToppingCounter => Toppings.Count;
        public void AddTopping(Topping topping)
        {
            Toppings.Add(topping);
        }
        public string TotalCalories()
        {
            return null;
        }
    }
}
