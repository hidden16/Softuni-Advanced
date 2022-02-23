using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();
            while (commands != "Tournament")
            {
                var tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                var pokemonHp = int.Parse(tokens[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHp);
                if (trainers.Any(x => x.Name == trainerName) == false)
                {
                    trainers.Add(new Trainer(trainerName));
                }
                Trainer currentTrainer = trainers.Find(t => t.Name == trainerName);
                currentTrainer.Pokemon.Add(pokemon);
                commands = Console.ReadLine();
            }
            commands = Console.ReadLine();
            while (commands != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemon.Any(x=>x.Element == commands))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemon.Count; i++)
                        {
                            trainer.Pokemon[i].Health -= 10;
                            if (trainer.Pokemon[i].Health <= 0)
                            {
                                trainer.Pokemon.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    
                }

                commands = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(x=>x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemon.Count}");
            }
        }
    }
}
