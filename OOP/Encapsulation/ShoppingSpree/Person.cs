using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        string name;
        decimal money;
        List<Product> products;
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
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
        public decimal Money
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
        public  List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }
        public override string ToString()
        {
            if (products.Count > 0 )
            {
                return $"{Name} - {products.Select(x => x.Name)}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }

    }
}
