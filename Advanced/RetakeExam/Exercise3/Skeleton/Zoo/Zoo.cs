using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public List<Animal> Animals { get; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (Animals.Count >= Capacity)
            {
                return "The zoo is full.";
            }
            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            List<Animal> animalsToRemove = Animals.Where(x => x.Species == species).ToList();
            var count = animalsToRemove.Count;
            Animals.RemoveAll(x => x.Species == species);
            return count;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animals = Animals.Where(x => x.Diet == diet).ToList();
            return animals;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            var animal = Animals.First(x => x.Weight == weight);
            return animal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var animals = Animals.Where(x => x.Length >= minimumLength && x.Length <= maximumLength).ToList();
            return $"There are {animals.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
