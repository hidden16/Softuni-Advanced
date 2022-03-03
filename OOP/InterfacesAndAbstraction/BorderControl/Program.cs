using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var name = input[0];
                var age = int.Parse(input[1]);
                if (input.Length == 4)
                {
                    var id = input[2];
                    var birthdate = input[3];
                    Human human = new Human(name,age,id,birthdate);
                    buyers.Add(human);
                }
                else if (input.Length == 3)
                {
                    var group = input[2];
                    Rebel rebel = new Rebel(name,age,group);
                    buyers.Add(rebel);
                }
            }
            var commands = Console.ReadLine();
            var sum = 0;
            while (commands != "End")
            {
                foreach (var buyer in buyers)
                {
                    if (buyer.Name == commands)
                    {
                        sum += buyer.BuyFood();
                    }
                }

                commands = Console.ReadLine();
            }
            Console.WriteLine(sum);
        }
    }
}
