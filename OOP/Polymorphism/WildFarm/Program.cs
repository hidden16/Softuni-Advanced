using System;
using System.Collections.Generic;
using WildFarm.Factories;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            Animal animal = null;
            Food food = null;
            var commands = Console.ReadLine();
            while (commands != "End")
            {
                var animalInput = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var foodInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                animal = AnimalTypeIdentificator.TypeIdentificator(animalInput);
                Console.WriteLine(animal.ProduceSound());
                food = FoodTypeIdentificator.FoodType(foodInput);
                animal.Eat(food);
                animals.Add(animal);
                commands = Console.ReadLine();
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
