using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Entities.Animals;

namespace WildFarm.Factories
{
    public static class AnimalTypeIdentificator
    {
        public static Animal TypeIdentificator(string[] input)
        {
            var type = input[0];
            var name = input[1];
            var weight = double.Parse(input[2]);
            if (type == "Owl")
            {
                var wingSize = double.Parse(input[3]);
                return new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                var wingSize = double.Parse(input[3]);
                return new Hen(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                var livingRegion = input[3];
                return new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                var livingRegion = input[3];
                return new Dog(name, weight, livingRegion);
            }
            else if (type == "Cat")
            {
                var livingRegion = input[3];
                var breed = input[4];
                return new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                var livingRegion = input[3];
                var breed = input[4];
                return new Tiger(name, weight, livingRegion, breed);
            }
            return null;
        }
    }
}
