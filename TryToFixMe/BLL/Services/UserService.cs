using Core.Models;
using System.Collections.Generic;
using Core.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public List<User> LoadRecords()
        {
            return _repository.LoadRecords();
        }
    }
}