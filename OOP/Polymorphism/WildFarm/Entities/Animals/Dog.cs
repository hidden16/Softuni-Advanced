using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Entities.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
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
                Weight += food.Quantity * 0.4;
            }
            catch (ArgumentException)
            {
                ExceptionHelper.PrintException(GetType().Name, food.GetType().Name);
            }
        }

        public override string ProduceSound()
        {
            return $"Woof!";
        }
    }
}
