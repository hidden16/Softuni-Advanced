using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nameMoneyInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var productNameMoney = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> person = new List<Person>();
            List<Product> product = new List<Product>();
            try
            {

                foreach (var item in nameMoneyInput)
                {
                    var personInput = item.Split("=");
                    var name = personInput[0];
                    var money = double.Parse(personInput[1]);
                    Person input = new Person(name, money);
                    person.Add(input);
                }
                foreach (var item in productNameMoney)
                {
                    var productInput = item.Split("=");
                    var name = productInput[0];
                    var cost = double.Parse(productInput[1]);
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
                    Console.WriteLine(currPerson.Buy(currProduct));
                    commands = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            foreach (var item in person)
            {
                Console.WriteLine(item);
            }
        }
    }
}
