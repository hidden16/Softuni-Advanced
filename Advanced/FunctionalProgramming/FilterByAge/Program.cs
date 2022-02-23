using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> people = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Student() {Name = input[0] , Age =int.Parse(input[1])});

            }
            var youngerOrOlder = Console.ReadLine();
            var years = int.Parse(Console.ReadLine());
            switch (youngerOrOlder)
            {
                case "younger":
                    people = people.Where(x => x.Age < years).ToList();
                    break;
                case "older":
                    people = people.Where(x => x.Age >= years).ToList();
                    break;
                default:
                    break;
            }
            var format = Console.ReadLine();
            switch (format)
            {
                case "name":
                    for (int i = 0; i < people.Count; i++)
                    {
                        Console.WriteLine(people[i].Name);
                    }
                    break;
                case "age":
                    for (int i = 0; i < people.Count; i++)
                    {
                        Console.WriteLine(people[i].Age);
                    }
                    break;
                case "name age":
                    for (int i = 0; i < people.Count; i++)
                    {
                        Console.WriteLine($"{people[i].Name} - {people[i].Age}");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
