using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Entities
{
    public class Person
    {
        public Person(string name, int age)
        {
            FullName = name;
            Age = age;
        }
        [MyRequired]
        public string FullName { get; set; }
        [MyRange(12,90)]
        public int Age { get; set; }
    }
}
