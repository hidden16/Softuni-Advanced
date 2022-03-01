using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sum = 0.0;
            Pizza pizza;
            Dough dough;
            Topping topping;
            var pizzainput = Console.ReadLine().Split(" ");
            if (pizzainput[0] != "Pizza")
            {
                return;
            }
            pizza = new Pizza(pizzainput[1]);
            while (true)
            {
                var commands = Console.ReadLine();
                if (commands == "END")
                {
                    break;
                }
                var tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                if (name == "Dough")
                {
                    var type = tokens[1];
                    var technique = tokens[2];
                    var grams = double.Parse(tokens[3]);
                    dough = new Dough(type, technique, grams);
                    sum += double.Parse(dough.CaloriesCalculator(dough));
                }
                else if (name == "Topping")
                {
                    var sauce = tokens[1];
                    var grams = double.Parse(tokens[2]);
                    topping = new Topping(sauce, grams);
                    pizza.AddTopping(topping);
                    sum += double.Parse(topping.CalculateToppingCal(topping));
                }
                if (pizza.Toppings.Count > 10)
                {
                    Console.WriteLine($"Number of toppings should be in range [0..10].");
                    return;
                }
            }
            Console.WriteLine($"{pizza.Name} - {sum:f2} Calories.");
        }
    }
}
