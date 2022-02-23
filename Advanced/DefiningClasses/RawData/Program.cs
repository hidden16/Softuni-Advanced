using System;
using System.Collections.Generic;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                Engine engine = new Engine();
                Cargo cargo = new Cargo();
                Tires[] tires = new Tires[4];
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = commands[0];
                var engineSpeed = int.Parse(commands[1]);
                var enginePower = int.Parse(commands[2]);
                var cargoWeight = int.Parse(commands[3]);
                var cargoType = commands[4];
                var tire1Pressure = double.Parse(commands[5]);
                var tire1Age = int.Parse(commands[6]);
                var tire2Pressure = double.Parse(commands[7]);
                var tire2Age = int.Parse(commands[8]);
                var tire3Pressure = double.Parse(commands[9]);
                var tire3Age = int.Parse(commands[10]);
                var tire4Pressure = double.Parse(commands[11]);
                var tire4Age = int.Parse(commands[12]);

                engine.Power = enginePower;
                engine.Speed = engineSpeed;
                cargo.Type = cargoType;
                cargo.Weight = cargoWeight;
                tires = new Tires[4]
                {
                    new Tires{TireAge = tire1Age , TirePressure = tire1Pressure },
                    new Tires{TireAge = tire2Age, TirePressure = tire2Pressure},
                    new Tires{TireAge = tire3Age, TirePressure = tire3Pressure},
                    new Tires{TireAge = tire4Age, TirePressure = tire4Pressure}
                };
                cars.Add(new Car(model, engine, cargo, tires));
            }
            var command = Console.ReadLine();
            if (command == "fragile")
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Cargo.Type == "fragile" && cars[i].Tires[0].TirePressure < 1 || cars[i].Tires[1].TirePressure < 1 || cars[i].Tires[2].TirePressure < 1 || cars[i].Tires[3].TirePressure < 1)
                    {
                        Console.WriteLine(cars[i].Model);
                    }
                }
            }
            else
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Cargo.Type == "flammable" && cars[i].Engine.Power > 250)
                    {
                        Console.WriteLine(cars[i].Model);
                    }
                }
            }
        }
    }
}
