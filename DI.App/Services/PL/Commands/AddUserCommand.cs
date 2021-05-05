using System;
using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using DI.App.Models;

namespace DI.App.Services.PL.Commands
{
    public class AddUserCommand : ICommand
    {

        public int Number { get; }
        public string DisplayName { get; }

        private readonly IUserStore userStore;


        public AddUserCommand(IUserStore userStore)
        {
            this.userStore = userStore;
            DisplayName = "Add user";
            Number = 1;
        }

        public void Execute()
        {
            var rnd = new Random();
            var id = rnd.Next(1, 101);

            userStore.AddUser(new User
            {
                Id = id,
                Name = $"User {id}"
            });
        }
    }
}