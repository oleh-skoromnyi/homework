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

        public CommandProcessor(IUserStore userStore, Dictionary<int, ICommand> commands)
        {
            this.commands = new Dictionary<int, ICommand>();

            var addUsers = new AddUserCommand(ref userStore);
            var listUsers = new ListUsersCommand(ref userStore);

            this.commands.Add(addUsers.Number, addUsers);
            this.commands.Add(listUsers.Number, listUsers);
        }

        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();
    }
}