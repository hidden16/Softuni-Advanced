using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        string name;
        double money;
        List<Product> products;
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
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
        public double Money
        {
            get { return money; }
            private set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException();
                    }
                    money = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Money cannot be negative");
                    Environment.Exit(0);
                }
            } 
        }
        public List<Product> Products
        {
            get { return products; }
            private set { products = value; }
        }
        public string Buy(Product product)
        {
            if (Money >= product.Cost)
            {
                Products.Add(product);
                return $"{Name} bought {product.Name}";
            }
            else
            {
                return $"{Name} can't afford {product.Name}";
            }
        }
        public override string ToString()
        {
            if (Products.Count > 0 )
            {
                return $"{Name} - {string.Join(", ", Products.Select(x=>x.Name))}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }

    }
}
