using System;
using System.Collections.Generic;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engine = new List<Engine>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = tokens[0];
                var power = int.Parse(tokens[1]);
                var displacement = @"n/a";
                var efficiency = @"n/a";
                if (tokens.Length >= 3 && tokens.Length < 4)
                {
                    if (char.IsDigit(tokens[2][0]))
                    {
                         displacement = tokens[2];
                    }
                    else
                    {
                        efficiency = tokens[2];
                    }
                }
                else if (tokens.Length >=4 && tokens.Length < 5)
                {
                     displacement = tokens[2];
                     efficiency = tokens[3];
                }
                engine.Add(new Engine(model, power, displacement, efficiency));
            }
            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = tokens[0];
                var engineType = tokens[1];
                var weight = @"n/a";
                var color = @"n/a";
                if (tokens.Length >= 3 && tokens.Length < 4)
                {
                    if (char.IsDigit(tokens[2][0]))
                    {
                        weight = tokens[2];
                    }
                    else
                    {
                        color = tokens[2];
                    }
                }
                else if (tokens.Length >=4 && tokens.Length < 5)
                {
                    weight = tokens[2];
                    color = tokens[3];
                }
                for (int j = 0; j < engine.Count; j++)
                {
                    if (engine[j].Model == engineType)
                    {
                        cars.Add(new Car(model, engine[j], weight, color));
                    }
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:\n  {car.Engine.Model}:\n    Power: {car.Engine.Power}\n    Displacement: {car.Engine.Displacement}\n    Efficiency: {car.Engine.Efficiency}\n  Weight: {car.Weight}\n  Color: {car.Color}");
            }
        }
    }
}
