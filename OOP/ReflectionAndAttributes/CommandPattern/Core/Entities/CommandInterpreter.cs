namespace CommandPattern.Core.Entities
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    internal class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var input = args.Split();
            var cmd = input[0] + "Command";
            var parameters = input.Skip(1).ToArray();
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(x=>x.Name == cmd)
                .FirstOrDefault();
            if (type == null)
            {
                throw new InvalidOperationException("Invalid input");
            }
            ICommand command = Activator.CreateInstance(type) as ICommand;
            var result = command.Execute(parameters);
            return result;
        }
    }
}
