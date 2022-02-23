using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            Roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }
        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => Roster.Count;
        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                Roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            var currPlayer = Roster.Find(x => x.Name == name);
            if (currPlayer != null)
            {
                Roster.Remove(currPlayer);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            var currPlayer = Roster.First(x => x.Name == name);
            if (currPlayer.Rank != "Member")
            {
                Roster.Remove(currPlayer);
                currPlayer.Rank = "Member";
                Roster.Add(currPlayer);
            }
        }
        public void DemotePlayer(string name)
        {
            var currPlayer = Roster.First(x=>x.Name == name);
            if (currPlayer.Rank != "Trial")
            {
                Roster.Remove(currPlayer);
                currPlayer.Rank = "Trial";
                Roster.Add(currPlayer);
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> list = new List<Player>();
            list = Roster.Where(x=>x.Class == @class).ToList();
            Roster.RemoveAll(x=>x.Class == @class);
            return list.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var item in Roster)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
