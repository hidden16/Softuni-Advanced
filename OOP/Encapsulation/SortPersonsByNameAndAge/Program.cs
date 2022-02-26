using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Team team = new Team("SoftUni");
            Person p1 = new Person("Iksan", "Ismet", 32, 4000);
            Person p2 = new Person("Ivan", "Grobarq", 17, 4000);
            Person p3 = new Person("Georgi", "Bugnatiq", 22, 4000);
            Person p4 = new Person("Sasho", "Boksiora", 26, 4000);
            List<Person> persons = new List<Person>();
            persons.Add(p1);
            persons.Add(p2);
            persons.Add(p3);
            persons.Add(p4);
            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count} players");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players");
        }
    }
}
