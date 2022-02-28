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
        public double Money
        {
            get { return money; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    money = value;
                }
                catch (Exception)
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Products.Count > 0)
            {
                sb.AppendLine($"{Name} - {string.Join(", ", Products)}");
            }
            else
            {
                sb.AppendLine($"{Name} - Nothing bought");
            }
            return sb.ToString().TrimEnd();
        }
        public string Buy(Product product)
        {
            if (Money >= product.Cost)
            {
                this.money -= product.Cost;
                products.Add(product);
                return $"{Name} bought {product.Name}";
            }
            else
            {
                return $"{Name} can't afford {product.Name}";
            }
        }
    }
}
