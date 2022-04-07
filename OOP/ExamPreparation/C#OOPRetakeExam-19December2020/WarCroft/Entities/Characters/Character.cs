using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        // TODO: Implement the rest of the class.
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
        public double BaseHealth { get; private set; }
        public double Health
        {
            get => health;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > BaseHealth)
                {
                    value = BaseHealth;
                }
                health = value;
            }
        }
        public double BaseArmor { get; private set; }
        public double Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                armor = value;
            }
        }
        public double AbilityPoints { get; set; }
        public IBag Bag { get; set; }
        public bool IsAlive { get; set; } = true;
        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            double remainingHitPoints = 0.0;
            bool armorFallen = false;
            if (Armor > 0)
            {
                if (Armor - hitPoints < 0)
                {
                    remainingHitPoints = hitPoints - Armor;
                    armorFallen = true;
                }
                Armor -= hitPoints;
            }
            if (Armor <= 0)
            {
                if (armorFallen)
                {
                    Health -= remainingHitPoints;
                }
                else
                {
                    health -= hitPoints;
                }
            }
            if (Health <= 0)
            {
                IsAlive = false;
            }
        }
        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}