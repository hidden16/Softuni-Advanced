using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }
        public IReadOnlyCollection<Person> FirstTeam { get { return firstTeam; } }
        public IReadOnlyCollection<Person> ReserveTeam { get { return reserveTeam; } }
        public void AddPlayer(Person person)
        {
            if (person.Age < 30)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
