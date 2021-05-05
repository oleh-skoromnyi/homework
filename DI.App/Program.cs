using DI.App.Services.PL;
using DI.App.Services;
using DI.App.Abstractions;
using System.Collections.Generic;
using DI.App.Services.PL.Commands;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            // Inversion of Control
            var dbEntity = new Dictionary<int, IDbEntity>();
            var dbServices = new InMemoryDatabaseService(dbEntity);
            var userStore = new UserStore(dbServices);
            var addUsers = new AddUserCommand(userStore);
            var listUsers = new ListUsersCommand(userStore);
            var commandProcessor = new CommandProcessor(addUsers,listUsers);
            var manager = new CommandManager(commandProcessor);

            manager.Start();
        }
    }
}
