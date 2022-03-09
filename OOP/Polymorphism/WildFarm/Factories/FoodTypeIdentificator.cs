using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Factories
{
    public static class FoodTypeIdentificator
    {
        public static Food FoodType(string[] input)
        {
            var type = input[0];
            var quantity = int.Parse(input[1]);
            if (type == "Vegetable")
            {
                return new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                return new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                return new Seeds(quantity);
            }
            return null;
        }
    }
}
