using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> typeChecker = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };
        private string type;
        private double grams;
        public Topping(string type , double grams)
        {
            Type = type;
            Grams = grams;
        }
        public string Type
        {
            get { return type; }
            private set
            {
                try
                {
                    if (typeChecker.ContainsKey(value.ToLower()))
                    {
                        type = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Cannot place {value} on top of your pizza.");
                    Environment.Exit(0);
                }
            }
        }
        public double Grams
        {
            get { return grams; }
            private set
            {
                try
                {
                    if (value < 1 || value > 50)
                    {
                        throw new Exception();
                    }
                    grams = value;
                }
                catch (Exception)
                {
                    Console.WriteLine($"{Type} weight should be in the range [1..50].");
                    Environment.Exit(0);
                }
            }
        }
        public string CalculateToppingCal(Topping topping)
        {
            if (topping.Type.ToLower() == "meat")
            {
                return $"{2 * grams * typeChecker["meat"]:f2}";
            }
            else if (topping.Type.ToLower() == "veggies")
            {
                return $"{2 * grams * typeChecker["veggies"]:f2}";
            }
            else if (topping.Type.ToLower() == "cheese")
            {
                return $"{2 * grams * typeChecker["cheese"]:f2}";
            }
            else if (topping.Type.ToLower() == "sauce")
            {
                return $"{2 * grams * typeChecker["sauce"]:f2}";
            }
            return null;
        }
    }
}
