using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Commands
{
    public class ExitCommand : ICommand
    {
        private const int ExitCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(ExitCode);

            return null;
        }
    }
}
