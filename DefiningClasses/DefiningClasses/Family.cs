using System;
using System.Collections.Generic;
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
            foreach (var member in People)
            {
                if (member.Value > oldestMemberAge)
                {
                    oldestMemberName = member.Key;
                    oldestMemberAge = member.Value;
                }
            }
            Console.WriteLine($"{oldestMemberName} {oldestMemberAge}");
        }
    }
}
