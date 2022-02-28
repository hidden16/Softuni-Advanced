using System;

namespace ShoppingSpree
{
    public class Product
    {
        string name;
        double cost;
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
        public string Name
        {
            get { return name; }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception();
                    }
                    name = value;
                }
                catch (Exception)
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
                        throw new Exception();
                    }
                    cost = value;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Money cannot be negative!");
                    Environment.Exit(0);
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}