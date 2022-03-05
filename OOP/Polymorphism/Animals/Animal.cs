using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FavouiteFood { get; protected set; }

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouiteFood = favouriteFood;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my favourite food is {FavouiteFood}";
        }
    }
}
