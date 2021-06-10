using EFPractice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.DA.MappingConfigs
{
    class UserMappingConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "sch");

            builder.HasKey(x => x.Id)
                    .HasName("PK_Users")
                    .IsClustered();

            builder.Property(x => x.UserName)
                    .HasMaxLength(128)
                    .IsUnicode();

            builder.Property(x => x.Email)
                    .HasMaxLength(128)
                    .IsUnicode(); 

            builder.Property(x => x.PasswordHash)
                     .HasMaxLength(128)
                     .IsUnicode();

            builder.HasMany(x => x.FilePermissions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_FilePermissions_Users_UserId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.DirectoryPermissions)
                 .WithOne(x => x.User)
                 .HasForeignKey(x => x.UserId)
                 .HasConstraintName("FK_DirectoryPermissions_Users_UserId")
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
