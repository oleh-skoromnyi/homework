﻿using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository
    {
        List<User> LoadRecords();
    }
}