using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> party;
        private Stack<Item> items;
        public WarController()
        {
            party = new List<Character>();
            items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            var type = args[0];
            var name = args[1];
            Character character;
            if (type == nameof(Warrior))
            {
                character = new Warrior(name);
            }
            else if (type == nameof(Priest))
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Join(ExceptionMessages.InvalidCharacterType, type));
            }
            party.Add(character);
            return String.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];
            Item item;
            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidItem, itemName));
            }
            items.Push(item);
            return String.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            var charName = args[0];
            var currChar = party.FirstOrDefault(x => x.Name == charName);
            if (currChar == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, charName));
            }
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            var currItem = items.Pop();
            currChar.Bag.AddItem(currItem);
            return String.Format(SuccessMessages.PickUpItem, charName, currItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            var charName = args[0];
            var itemName = args[1];
            var currChar = party.FirstOrDefault(x=>x.Name == charName);
            if (currChar == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, charName));
            }
            var item = currChar.Bag.GetItem(itemName);
            currChar.UseItem(item);
            return String.Format(SuccessMessages.UsedItem, charName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in party.OrderByDescending(x=>x.IsAlive).ThenByDescending(x=>x.Health))
            {
                var aliveOrDead = player.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{player.Name} - HP: {player.Health}/{player.BaseHealth}, AP: {player.Armor}/{player.BaseArmor}, Status: {aliveOrDead}");
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];
            var attacker = party.FirstOrDefault(x => x.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            var receiver = party.FirstOrDefault(x => x.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            if (attacker is Priest)
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
            }
           ((Warrior)attacker).Attack(receiver);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter,
                attackerName, receiverName, attacker.AbilityPoints,
                receiverName, receiver.Health, receiver.BaseHealth, 
                receiver.Armor, receiver.BaseArmor));
            if (!receiver.IsAlive)
            {
                sb.AppendLine(String.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];
            var healer = party.FirstOrDefault(x => x.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            var receivingHeal = party.FirstOrDefault(x => x.Name == healingReceiverName);
            if (receivingHeal == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }
            if (healer is Warrior)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            ((Priest)healer).Heal(receivingHeal);
            return String.Format(SuccessMessages.HealCharacter, healer.Name, receivingHeal.Name, healer.AbilityPoints, receivingHeal.Name, receivingHeal.Health);
        }
    }
}
