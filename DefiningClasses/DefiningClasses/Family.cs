using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        Dictionary<string, int> people = new Dictionary<string, int>();
        public Dictionary<string,int> People { get { return people; }}
        public void AddMember(Person member)
        {
            People.Add(member.Name, member.Age);
        }
        public void GetOldestMember()
        {
            var oldestMemberName = String.Empty;
            var oldestMemberAge = int.MinValue;
            foreach (var member in People.Where(x => x.Value > 30).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{member.Key} - {member.Value}");
            }
        }
    }
}
