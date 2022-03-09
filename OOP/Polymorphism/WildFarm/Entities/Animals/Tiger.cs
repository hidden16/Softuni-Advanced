using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Entities.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
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
                Weight += food.Quantity * 1;
            }
            catch (ArgumentException)
            {
                ExceptionHelper.PrintException(GetType().Name, food.GetType().Name);
            }
        }

        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }
    }
}
