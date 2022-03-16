using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter interpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.interpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                var commands = Console.ReadLine();
                Console.WriteLine(interpreter.Read(commands));
            }
        }
    }
}
