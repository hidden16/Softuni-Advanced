using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Human : Citizen, IBirthdateable, IBuyer
    {
        public Human(string name, int age, string id,string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string Id { get; set; }
        public string Birthdate { get; set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            return 10;
        }

        public override bool FakeId(string id, string checker)
        {
            if (id.EndsWith(checker))
            {
                return true;
            }
            return false;
        }
    }
}
