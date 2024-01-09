using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandInfo = args.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string command = commandInfo[0] + "Command";
            Type type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == command);
            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var commandInstance = Activator.CreateInstance(type) as ICommand;
            string result = commandInstance.Execute(commandInfo.Skip(1).ToArray());

            return result;
        }
    }
}
