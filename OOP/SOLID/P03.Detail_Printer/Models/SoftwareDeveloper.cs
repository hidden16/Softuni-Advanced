using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Models
{
    public class SoftwareDeveloper : Employee, IEmployee
    {
        public SoftwareDeveloper(string name, int experience) : base(name)
        {
            this.Experience = experience;
        }
        public int Experience { get; set; }
        public override string ToString()
        {
            return $"{Name} - Software Developer with {Experience} years of experience in C#";
        }
    }
}
