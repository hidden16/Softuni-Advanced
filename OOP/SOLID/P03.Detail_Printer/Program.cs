using P03.Detail_Printer;
using P03.Detail_Printer.Models;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<IEmployee> employees = new List<IEmployee>();
            IEmployee employee;
            List<string> documents = new List<string>();
            documents.Add("A1");
            documents.Add("A2");
            documents.Add("A3");
            documents.Add("B1");
            employee = new Manager("Bogo", documents);
            employees.Add(employee);
            employee = new Employee("Ivan");
            employees.Add(employee);
            documents.Add("C2");
            documents.Add("C3");
            documents.Add("C4");
            employee = new Manager("Dragomir", documents);
            employees.Add(employee);
            employee = new SoftwareDeveloper("Iksan", 5);
            employees.Add(employee);
            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();

        }
    }
}
