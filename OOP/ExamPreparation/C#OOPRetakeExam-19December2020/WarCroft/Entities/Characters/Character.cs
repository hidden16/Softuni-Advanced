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
        public Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
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
        public double BaseHealth { get; }
        public double Health
        {
            get => health;
            internal set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > BaseHealth)
                {
                    value = BaseHealth;
                }
                health = value;
            }
        }
        public double BaseArmor { get; }
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
        public double AbilityPoints { get; private set; }
        public IBag Bag { get; set; }
        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            double leftoverHitpoints = 0.0;
            var armorRemoved = false;
            if (Armor > 0)
            {
                if (hitPoints > Armor)
                {
                    leftoverHitpoints = hitPoints - Armor;
                    armorRemoved = true;
                }
                Armor -= hitPoints;
            }
            if (armorRemoved)
            {
                Health -= leftoverHitpoints;
            }
            else
            {
                if (Armor <= 0)
                {
                    Health -= hitPoints;
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