using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(x=>x.Alcohol);
        public void Add(Ingredient ingredient)
        {
            var currCocktail = Ingredients.Find(x=>x.Name == ingredient.Name);
            if (currCocktail == null && ingredient.Alcohol <= MaxAlcoholLevel && Ingredients.Count <= Capacity)
            {
                Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            var currCocktail = Ingredients.Find(x => x.Name == name);
            if (currCocktail!=null)
            {
                Ingredients.Remove(currCocktail);
                return true;
            }
            return false;
        }
        public Ingredient FindIngredient(string name)
        {
            var currIngredient = Ingredients.Find(x=>x.Name == name);
            if (currIngredient != null)
            {
                return currIngredient;
            }
            return null;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            var mostAlcoholic = Ingredients.OrderByDescending(x => x.Alcohol).First();
            return mostAlcoholic;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
