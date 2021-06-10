using System;
using System.Linq;
using System.Reflection;
using EFPractice.BLL.Services;
using EFPractice.Core.Entities;
using EFPractice.DA.Contexts;
using EFPractice.DA.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EFPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FileDbContext>()
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=FileDb;Trusted_Connection=True;",
                    o =>
                    {
                        o.MigrationsHistoryTable("Migrations", "sch");
                        o.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    });

            using (var dbContext = new FileDbContext(optionsBuilder.Options))
            {
                Console.WriteLine("Task 1");
                var service = new FileService(new FileRepository(dbContext), new DirectoryRepository(dbContext));
                var result1 = service.GetAvailableFilesInDirectory(new User { Id = 2 }, new Directory { Id = 3 }, 1, 10);
                Console.WriteLine(string.Join(',',result1.Result.Items.Where(x=>x.FilePermissions.Any()).Select(x=>x.Title + x.Extension)));
                Console.WriteLine("Task 2");
                var result2 = service.GetDirectoryAndSub(new Directory { Id = 1 }, 1, 10);
                Console.WriteLine(string.Join('\n', result2.Result.OfType<Directory>().Select(x => x.Title)));
                Console.WriteLine(string.Join('\n', result2.Result.OfType<File>().Select(x => x.Title + x.Extension)));
                Console.WriteLine("Task 3");
                var result3 = service.GetDirectoryAndSubWithFullPath(new Directory { Id = 1 }, 1, 10);
                Console.WriteLine(string.Join('\n', result3));
                Console.WriteLine("Task 4");
                var result4 = service.GetAvailableDirectoryAndSub(new User { Id = 2 },new Directory { Id = 1 }, 1, 10);
                Console.WriteLine(string.Join('\n', result4.Result.OfType<Directory>().Select(x => x.Title)));
                Console.WriteLine(string.Join('\n', result4.Result.OfType<File>().Select(x => x.Title + x.Extension)));
                Console.WriteLine("Task 5");
                var result5 = service.GetAvailableDirectoryAndSubWithFullPath(new User { Id = 1 },new Directory { Id = 1 }, 1, 10);
                Console.WriteLine(string.Join('\n', result5));
                Console.WriteLine("Task 6");
                var result6 = service.GetFilesInFolderCountAndAvailableForUser(new User { Id = 1 }, new Directory { Id = 3 });
                Console.WriteLine($"All files: {result6[0]} || Available: {result6[1]}");
                Console.WriteLine("Task 7");
                var result7 = service.GetGroupedFileCountByType();
                Console.WriteLine(string.Join('\n', result7));
            }
        }
    }
}
