using System;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private double cost;
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                try
                {
                    if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException();
                    }
                    name = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Name cannot be empty");
                    Environment.Exit(0);
                }
            }
        }
        public double Cost
        {
            get { return cost; }
            private set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException();
                    }
                    cost = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
            }
        }
    }
}