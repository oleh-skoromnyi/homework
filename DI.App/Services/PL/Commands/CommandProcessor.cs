using System.Collections.Generic;
using System.Linq;
using DI.App.Abstractions;
using DI.App.Services.PL.Commands;
using DI.App.Abstractions.BLL;

namespace DI.App.Services.PL
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<int, ICommand> commands;

        public CommandProcessor(params ICommand[] commands)
        {
            this.commands = new Dictionary<int, ICommand>();
            foreach(ICommand command in commands)
            {
                this.commands.Add(command.Number, command);
            }
        }

        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();
    }
}