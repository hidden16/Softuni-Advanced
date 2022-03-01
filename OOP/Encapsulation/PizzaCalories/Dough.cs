using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        Dictionary<string, double> typeChecker = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 },

        };
        Dictionary<string, double> techniqueChecker = new Dictionary<string, double>()
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };
        private string type;
        private string technique;
        private double grams;
        private double total;
        public Dough(string type, string technique, double grams)
        {
            Type = type;
            Technique = technique;
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
                    Console.WriteLine($"Invalid type of dough.");
                    Environment.Exit(0);
                }
            }
        }
        public string Technique
        {
            get { return technique; }
            private set
            {
                try
                {
                    if (techniqueChecker.ContainsKey(value.ToLower()))
                    {
                        technique = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Invalid type of dough.");
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
                    if (value < 1 || value > 200)
                    {
                        throw new Exception();
                    }
                    grams = value;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Dough weight should be in the range [1..200].");
                    Environment.Exit(0);
                }
            }
        }
        public string CaloriesCalculator(Dough input)
        {

            if (input.Type.ToLower() == "white")
            {
                if (input.Technique.ToLower() == "crispy")
                {
                    return $"{2 * Grams * typeChecker["white"] * techniqueChecker["crispy"]:f2}";
                }
                else if (input.Technique.ToLower() == "chewy")
                {
                    return $"{2 * Grams * typeChecker["white"] * techniqueChecker["chewy"]:f2}";
                }
                else if (input.Technique.ToLower() == "homemade")
                {
                    return $"{2 * Grams * typeChecker["white"] * techniqueChecker["homemade"]:f2}";
                }
            }
            else if (input.Type.ToLower() == "wholegrain")
            {
                if (input.Technique.ToLower() == "crispy")
                {
                    return $"{2 * Grams * typeChecker["wholegrain"] * techniqueChecker["crispy"]:f2}";
                }
                else if (input.Technique.ToLower() == "chewy")
                {
                    return $"{2 * Grams * typeChecker["wholegrain"] * techniqueChecker["chewy"]:f2}";
                }
                else if (input.Technique.ToLower() == "homemade")
                {
                    return $"{2 * Grams * typeChecker["wholegrain"] * techniqueChecker["homemade"]:f2}";
                }
            }
            return null;
        }
    }

}

