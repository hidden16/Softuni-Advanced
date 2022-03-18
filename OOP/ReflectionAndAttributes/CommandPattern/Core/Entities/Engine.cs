namespace CommandPattern.Core.Entities
{
using System;
using Contracts;
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter cmdInt)
        {
            commandInterpreter = cmdInt;
        }
        public void Run()
        {
            while (true)
            {
                var commands = Console.ReadLine();
                var result = commandInterpreter.Read(commands);
                Console.WriteLine(result);
            }
        }
    }
}
