using System;

namespace ShoppingSpree
{
    public class Product
    {
        string name;
        decimal cost;
        public Product(string name, decimal cost)
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
        public decimal Cost { get; set; }
    }
}