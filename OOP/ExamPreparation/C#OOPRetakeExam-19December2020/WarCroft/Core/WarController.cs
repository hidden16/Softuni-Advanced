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
            Character character;
            var type = args[0];
            var name = args[1];
            if (type == "Warrior")
            {
                character = new Warrior(name);
            }
            else if (type == "Priest")
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, type));
            }
            party.Add(character);
            return String.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            Item item;
            var itemName = args[0];
            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
            items.Push(item);
            return String.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            Character character = party.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            var pickedUpItem = items.Pop();
            character.Bag.AddItem(pickedUpItem);
            return String.Format(SuccessMessages.PickUpItem, characterName, pickedUpItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];
            var character = party.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return String.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
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
            var attCharacter = party.FirstOrDefault(x => x.Name == attackerName);
            if (attCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            var deffCharacter = party.FirstOrDefault(x => x.Name == receiverName);
            if (deffCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (attCharacter is IHealer)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
                ((Warrior)attCharacter).Attack(deffCharacter);
            StringBuilder sb = new StringBuilder();
            sb.Append($"{attackerName} attacks {receiverName} for {attCharacter.AbilityPoints} hit points! ");
            sb.Append($"{receiverName} has {deffCharacter.Health}/{deffCharacter.BaseHealth} HP and ");
            sb.Append($"{deffCharacter.Armor}/{deffCharacter.BaseArmor} AP left!");
            if (deffCharacter.IsAlive == false)
            {
                sb.AppendLine();
                sb.AppendLine($"{deffCharacter.Name} is dead!");
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];
            var healer = party.FirstOrDefault(x => x.Name == healerName);
            var receivingHeal = party.FirstOrDefault(x => x.Name == healingReceiverName);
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (receivingHeal == null)
            {

                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }
            if (healer is IAttacker)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            ((Priest)healer).Heal(receivingHeal);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{healer.Name} heals {receivingHeal.Name} for {healer.AbilityPoints}! {receivingHeal.Name} has {receivingHeal.Health} health now!");
            return sb.ToString().TrimEnd();
        }
    }
}
