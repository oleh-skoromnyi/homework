using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IUserService
    {
        List<User> LoadRecords();
    }
}