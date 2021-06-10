﻿// <auto-generated />
using System;
using EFPractice.DA.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFPractice.DA.Migrations
{
    [DbContext(typeof(FileDbContext))]
    partial class FileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sch")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFPractice.Core.Entities.Directory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id")
                        .HasName("PK_Directories")
                        .IsClustered();

                    b.ToTable("Directories", "sch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "C:"
                        },
                        new
                        {
                            Id = 2,
                            Title = "D:"
                        },
                        new
                        {
                            Id = 3,
                            ParentId = 1,
                            Title = "System"
                        });
                });

            modelBuilder.Entity("EFPractice.Core.Entities.DirectoryPermission", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("DirectoryId")
                        .HasColumnType("int");

                    b.Property<bool>("CanRead")
                        .HasColumnType("bit");

                    b.Property<bool>("CanWrite")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "DirectoryId");

                    b.HasIndex("DirectoryId");

                    b.ToTable("DirectoryPermission");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DirectoryId = 1,
                            CanRead = true,
                            CanWrite = true
                        },
                        new
                        {
                            UserId = 1,
                            DirectoryId = 2,
                            CanRead = true,
                            CanWrite = true
                        },
                        new
                        {
                            UserId = 1,
                            DirectoryId = 3,
                            CanRead = true,
                            CanWrite = true
                        },
                        new
                        {
                            UserId = 2,
                            DirectoryId = 1,
                            CanRead = true,
                            CanWrite = false
                        },
                        new
                        {
                            UserId = 2,
                            DirectoryId = 2,
                            CanRead = true,
                            CanWrite = true
                        },
                        new
                        {
                            UserId = 2,
                            DirectoryId = 3,
                            CanRead = false,
                            CanWrite = false
                        });
                });

            modelBuilder.Entity("EFPractice.Core.Entities.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DirectoryId")
                        .HasColumnType("int");

                    b.Property<string>("Extension")
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Size")
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Title")
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DirectoryId");

                    b.ToTable("Files", "sch");
                });

            modelBuilder.Entity("EFPractice.Core.Entities.FilePermission", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<bool>("CanRead")
                        .HasColumnType("bit");

                    b.Property<bool>("CanWrite")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "FileId");

                    b.HasIndex("FileId");

                    b.ToTable("FilePermission");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FileId = 1,
                            CanRead = true,
                            CanWrite = true
                        },
                        new
                        {
                            UserId = 2,
                            FileId = 1,
                            CanRead = true,
                            CanWrite = true
                        },
                        new
                        {
                            UserId = 1,
                            FileId = 2,
                            CanRead = true,
                            CanWrite = true
                        },
                        new
                        {
                            UserId = 2,
                            FileId = 2,
                            CanRead = false,
                            CanWrite = false
                        },
                        new
                        {
                            UserId = 1,
                            FileId = 3,
                            CanRead = true,
                            CanWrite = true
                        },
                        new
                        {
                            UserId = 2,
                            FileId = 3,
                            CanRead = false,
                            CanWrite = false
                        },
                        new
                        {
                            UserId = 1,
                            FileId = 4,
                            CanRead = true,
                            CanWrite = true
                        },
                        new
                        {
                            UserId = 2,
                            FileId = 4,
                            CanRead = false,
                            CanWrite = false
                        });
                });

            modelBuilder.Entity("EFPractice.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UserName")
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id")
                        .HasName("PK_Users")
                        .IsClustered();

                    b.ToTable("Users", "sch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@company.com",
                            PasswordHash = "12213w12wd",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "lowrider@gmail.com",
                            PasswordHash = "12dwwaw12wd",
                            UserName = "lowrider"
                        });
                });

            modelBuilder.Entity("EFPractice.Core.Entities.AudioFile", b =>
                {
                    b.HasBaseType("EFPractice.Core.Entities.File");

                    b.Property<string>("Bitrate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChannelCount")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("SampleRate")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("AudioFiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectoryId = 2,
                            Extension = ".mp3",
                            Size = "5 Mb",
                            Title = "musicfile",
                            Type = "AudioFile",
                            Bitrate = "320kbps",
                            ChannelCount = 2,
                            Duration = new TimeSpan(0, 0, 3, 41, 0),
                            SampleRate = "44100"
                        });
                });

            modelBuilder.Entity("EFPractice.Core.Entities.ImageFile", b =>
                {
                    b.HasBaseType("EFPractice.Core.Entities.File");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.ToTable("ImageFiles");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            DirectoryId = 1,
                            Extension = ".jpg",
                            Size = "1 Mb",
                            Title = "jpgImage",
                            Type = "ImageFile",
                            Height = 1080,
                            Width = 1920
                        });
                });

            modelBuilder.Entity("EFPractice.Core.Entities.TextFile", b =>
                {
                    b.HasBaseType("EFPractice.Core.Entities.File");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("TextFiles");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            DirectoryId = 3,
                            Extension = ".txt",
                            Size = "12 Kb",
                            Title = "TextFile",
                            Type = "TextFile",
                            Content = "Many many strings"
                        });
                });

            modelBuilder.Entity("EFPractice.Core.Entities.VideoFile", b =>
                {
                    b.HasBaseType("EFPractice.Core.Entities.File");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.ToTable("VideoFiles");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            DirectoryId = 3,
                            Extension = ".mp4",
                            Size = "2 Gb",
                            Title = "mp4File",
                            Type = "VideoFile",
                            Duration = new TimeSpan(0, 1, 15, 21, 0),
                            Height = 1080,
                            Width = 1920
                        });
                });

            modelBuilder.Entity("EFPractice.Core.Entities.Directory", b =>
                {
                    b.HasOne("EFPractice.Core.Entities.Directory", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_Directories_Parents_ParentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("EFPractice.Core.Entities.DirectoryPermission", b =>
                {
                    b.HasOne("EFPractice.Core.Entities.Directory", "Directory")
                        .WithMany("DirectoryPermissions")
                        .HasForeignKey("DirectoryId")
                        .HasConstraintName("FK_DirectoryPermissions_Directories_DirectoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EFPractice.Core.Entities.User", "User")
                        .WithMany("DirectoryPermissions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_DirectoryPermissions_Users_UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Directory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFPractice.Core.Entities.File", b =>
                {
                    b.HasOne("EFPractice.Core.Entities.Directory", "Directory")
                        .WithMany("Files")
                        .HasForeignKey("DirectoryId")
                        .HasConstraintName("FK_Directories_Files_DirectoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Directory");
                });

            modelBuilder.Entity("EFPractice.Core.Entities.FilePermission", b =>
                {
                    b.HasOne("EFPractice.Core.Entities.File", "File")
                        .WithMany("FilePermissions")
                        .HasForeignKey("FileId")
                        .HasConstraintName("FK_FilePermissions_Files_FileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EFPractice.Core.Entities.User", "User")
                        .WithMany("FilePermissions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_FilePermissions_Users_UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFPractice.Core.Entities.AudioFile", b =>
                {
                    b.HasOne("EFPractice.Core.Entities.File", null)
                        .WithOne()
                        .HasForeignKey("EFPractice.Core.Entities.AudioFile", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFPractice.Core.Entities.ImageFile", b =>
                {
                    b.HasOne("EFPractice.Core.Entities.File", null)
                        .WithOne()
                        .HasForeignKey("EFPractice.Core.Entities.ImageFile", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFPractice.Core.Entities.TextFile", b =>
                {
                    b.HasOne("EFPractice.Core.Entities.File", null)
                        .WithOne()
                        .HasForeignKey("EFPractice.Core.Entities.TextFile", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFPractice.Core.Entities.VideoFile", b =>
                {
                    b.HasOne("EFPractice.Core.Entities.File", null)
                        .WithOne()
                        .HasForeignKey("EFPractice.Core.Entities.VideoFile", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFPractice.Core.Entities.Directory", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("DirectoryPermissions");

                    b.Navigation("Files");
                });

            modelBuilder.Entity("EFPractice.Core.Entities.File", b =>
                {
                    b.Navigation("FilePermissions");
                });

            modelBuilder.Entity("EFPractice.Core.Entities.User", b =>
                {
                    b.Navigation("DirectoryPermissions");

                    b.Navigation("FilePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
