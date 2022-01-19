using System;
using System.Collections.Generic;
using System.Linq;
namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var grade = decimal.Parse(input[1]);
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal> { grade });
                    continue;
                }
                students[name].Add(grade);
            }
            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
