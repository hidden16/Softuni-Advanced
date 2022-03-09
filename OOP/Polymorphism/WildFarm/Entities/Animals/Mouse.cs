using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Entities.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            try
            {
                if (!(food is Vegetable || food is Fruit))
                {
                    throw new ArgumentException();
                }
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.1;
            }
            catch (ArgumentException)
            {
                ExceptionHelper.PrintException(GetType().Name, food.GetType().Name);
            }
        }

        public override string ProduceSound()
        {
            return $"Squeak";
        }
    }
}
