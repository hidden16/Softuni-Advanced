using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            Students = new List<Student>();
            Capacity = capacity;
        }

        public List<Student> Students { get; set; }
        public int Capacity { get; set; }
        public int Count => Students.Count;
        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return $"No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            var currStudent = Students.Find(x => x.FirstName == firstName && x.LastName == lastName);
            if (currStudent != null)
            {
                Students.Remove(currStudent);
                return $"Dismissed student {currStudent.FirstName} {currStudent.LastName}";
            }
            return $"Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            if (Students.All(x=>x.Subject != subject))
            {
                return $"No students enrolled for the subject";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine($"Students:");
            foreach (var item in Students.Where(x=>x.Subject == subject))
            {
                sb.AppendLine($"{item.FirstName} {item.LastName}");
            }
            return sb.ToString().TrimEnd();
        }
        public int GetStudentsCount()
        {
            return Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            var currStudent = Students.Find(x => x.FirstName == firstName && x.LastName == lastName);
            if (currStudent != null)
            {
                return currStudent;
            }
            return null;
        }
    }
}
