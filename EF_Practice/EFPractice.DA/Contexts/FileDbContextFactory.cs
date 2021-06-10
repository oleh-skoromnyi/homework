using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EFPractice.DA.Contexts
{ 
    internal class FileDbContextFactory : IDesignTimeDbContextFactory<FileDbContext>
    {
        public FileDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FileDbContext>()
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=FileDb;Trusted_Connection=True;",
                    o =>
                    {
                        o.MigrationsHistoryTable("Migrations", "sch");
                        o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    });

            return new FileDbContext(optionsBuilder.Options);
        }
    }
}
