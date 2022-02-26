using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        string name;
        int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
