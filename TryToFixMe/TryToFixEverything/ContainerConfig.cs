using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using DAL.Repositories;
using Core.Interfaces;
using Core.Models;

namespace ConsoleApp8
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserRepository>().As<IRepository>();
            builder.RegisterType<UserService>().As<IUserService>();
            return builder.Build();
        }
    }
}
