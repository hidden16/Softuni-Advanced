using System.Collections.Generic;
using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            var commands = Console.ReadLine();
            while (commands != "Beast!")
            {
                var animalInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = animalInput[0];
                var age = int.Parse(animalInput[1]);
                var gender = animalInput[2];
                if (commands == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (commands == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }
                else if (commands == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (commands == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }
                else if (commands == "Tomcat")
                {
                    Tomcat cat = new Tomcat(name, age);
                    animals.Add(cat);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                commands = Console.ReadLine();
            }
            foreach (var item in animals)
            {
                Console.WriteLine(item.GetType().Name);
                Console.WriteLine($"{item.Name} {item.Age} {item.Gender}");
                Console.WriteLine(item.ProduceSound());
            }
        }
    }
}
