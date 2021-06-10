using EFPractice.Core.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EFPractice.DA.Contexts
{
    public class FileDbContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<VideoFile> VideoFiles { get; set; }
        public DbSet<TextFile> TextFiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Directory> Directories { get; set; }

        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sch");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<FilePermission>(builder =>
            {
                builder.HasKey(x => new { x.UserId, x.FileId });
            });
            modelBuilder.Entity<DirectoryPermission>(builder =>
            {
                builder.HasKey(x => new { x.UserId, x.DirectoryId });
            });

            modelBuilder.Entity<AudioFile>().ToTable("AudioFiles");
            modelBuilder.Entity<ImageFile>().ToTable("ImageFiles");
            modelBuilder.Entity<VideoFile>().ToTable("VideoFiles");
            modelBuilder.Entity<TextFile>().ToTable("TextFiles");
            Init(modelBuilder);
        }

        private void Init(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id=1, UserName="admin", Email="admin@company.com", PasswordHash = "12213w12wd"},
                    new User { Id=2, UserName="lowrider", Email="lowrider@gmail.com", PasswordHash = "12dwwaw12wd"}
                });

            modelBuilder.Entity<Directory>().HasData(
                new Directory[]
                {
                    new Directory { Id=1, ParentId=null, Title=@"C:"},
                    new Directory { Id=2, ParentId=null, Title=@"D:"},
                    new Directory { Id=3, ParentId=1, Title=@"System"},
                });

            modelBuilder.Entity<AudioFile>().HasData(
                new AudioFile[]
                {
                    new AudioFile { Id = 1, Bitrate = "320kbps", ChannelCount = 2,
                        Type = "AudioFile",
                        DirectoryId = 2, Duration = new TimeSpan(0,3,41),
                        Extension=".mp3", SampleRate = "44100", 
                        Size = "5 Mb", Title="musicfile"}
                }) ;
            modelBuilder.Entity<ImageFile>().HasData(
                new ImageFile[]
                {
                    new ImageFile { Id = 2, DirectoryId = 1, Extension = ".jpg",
                        Type = "ImageFile",
                        Size = "1 Mb", Height = 1080, Width = 1920, Title = "jpgImage" }
                });
            modelBuilder.Entity<VideoFile>().HasData(
                new VideoFile[]
                {
                    new VideoFile { Id = 3, DirectoryId = 3, Extension = ".mp4",
                        Type = "VideoFile",
                        Size = "2 Gb", Height = 1080, Width = 1920, 
                        Duration = new TimeSpan(1,15,21), Title = "mp4File"}
                });
            modelBuilder.Entity<TextFile>().HasData(
                new TextFile[]
                {
                    new TextFile { Id = 4, DirectoryId = 3, Extension = ".txt",
                        Type = "TextFile",
                        Size = "12 Kb", Content = "Many many strings", Title = "TextFile"}
                });

            modelBuilder.Entity<FilePermission>().HasData(
                new FilePermission[]
                {
                    new FilePermission {FileId = 1, UserId = 1, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 1, UserId = 2, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 2, UserId = 1, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 2, UserId = 2, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 3, UserId = 1, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 3, UserId = 2, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 4, UserId = 1, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 4, UserId = 2, CanRead = false, CanWrite = false }
                });

            modelBuilder.Entity<DirectoryPermission>().HasData(
                new DirectoryPermission[]
                {
                    new DirectoryPermission {DirectoryId = 1, UserId = 1, CanRead = true, CanWrite = true },
                    new DirectoryPermission {DirectoryId = 2, UserId = 1, CanRead = true, CanWrite = true },
                    new DirectoryPermission {DirectoryId = 3, UserId = 1, CanRead = true, CanWrite = true },
                    new DirectoryPermission {DirectoryId = 1, UserId = 2, CanRead = true, CanWrite = false },
                    new DirectoryPermission {DirectoryId = 2, UserId = 2, CanRead = true, CanWrite = true },
                    new DirectoryPermission {DirectoryId = 3, UserId = 2, CanRead = false, CanWrite = false }
                });
        }
    }
}
