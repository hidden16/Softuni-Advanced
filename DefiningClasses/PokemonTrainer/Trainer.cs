using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemon { get; set; }
        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemon = new List<Pokemon>();
        }
    }
}
