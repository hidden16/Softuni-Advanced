using System;
using System.Collections.Generic;

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
                var money = decimal.Parse(personInput[1]);
                Person input = new Person(name, money);
                person.Add(input);
            }
            var productNameMoney = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> product = new List<Product>();
            foreach (var item in productNameMoney)
            {
                var productInput = item.Split("=");
                var name = productInput[0];
                var cost = decimal.Parse(productInput[1]);
                Product input = new Product(name, cost);
                product.Add(input);
            }
            var commands = Console.ReadLine();
            while (commands != "END")
            {
                var tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var productName = tokens[1];
                var currPerson = person.Find(x => x.Name == name);
                var currProduct = product.Find(x => x.Name == productName);
                if (currPerson != null && currProduct != null)
                {
                    var index = person.IndexOf(currPerson);
                    if (currPerson.Money >= currProduct.Cost)
                    {
                        person[index].Products.Add(currProduct);
                        currPerson.Money -= currProduct.Cost;
                        Console.WriteLine($"{person[index].Name} bought {currProduct.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person[index].Name} can't afford {currProduct.Name}");
                    }
                }
                commands = Console.ReadLine();
            }
            foreach (var item in person)
            {
                Console.WriteLine(item);
            }
        }
    }
}
