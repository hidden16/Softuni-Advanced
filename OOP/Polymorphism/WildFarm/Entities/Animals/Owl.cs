using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Entities.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            try
            {
                if (!(food is Meat))
                {
                    throw new ArgumentException();
                }
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.25;
            }
            catch (ArgumentException)
            {
                ExceptionHelper.PrintException(GetType().Name, food.GetType().Name);
            }
        }

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
