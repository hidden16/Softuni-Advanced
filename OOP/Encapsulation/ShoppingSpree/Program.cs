using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nameMoneyInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> person = new List<Person>();
            foreach (var item in nameMoneyInput)
            {
                var personInput = item.Split("=");
                var name = personInput[0];
                var money = double.Parse(personInput[1]);
                person.Add(new Person(name, money));
                
            }
            var productNameMoney = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> product = new List<Product>();
            foreach (var item in productNameMoney)
            {
                var productInput = item.Split("=");
                var name = productInput[0];
                var cost = double.Parse(productInput[1]);
                product.Add(new Product(name, cost));
            }
            var commands = Console.ReadLine();
            while (commands != "END")
            {
                var tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var personName = tokens[0];
                var productName = tokens[1];
                var currPerson = person.Find(x => x.Name == personName);
                var currProduct = product.Find(x => x.Name == productName);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(currPerson.Buy(currProduct));
                Console.WriteLine(sb.ToString().TrimEnd());
                sb.Clear();
                commands = Console.ReadLine();
            }
            foreach (var item in person)
            {
                Console.WriteLine(item);
            }
        }
    }
}
