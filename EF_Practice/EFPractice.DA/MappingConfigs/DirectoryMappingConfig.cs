using EFPractice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.DA.MappingConfigs
{
    class DirectoryMappingConfig : IEntityTypeConfiguration<Directory>
    {
        public void Configure(EntityTypeBuilder<Directory> builder)
        {
            builder.ToTable("Directories", "sch");

            builder.HasKey(x => x.Id)
                    .HasName("PK_Directories")
                    .IsClustered();

            builder.Property(x => x.Title)
                    .HasMaxLength(128)
                    .IsUnicode();

            builder.HasMany(x => x.DirectoryPermissions)
                .WithOne(x => x.Directory)
                .HasForeignKey(x => x.DirectoryId)
                .HasConstraintName("FK_DirectoryPermissions_Directories_DirectoryId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Files)
                 .WithOne(x => x.Directory)
                 .HasForeignKey(x => x.DirectoryId)
                 .HasConstraintName("FK_Files_Directories_DirectoryId")
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Parent)
                .WithMany(x=>x.Children)
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FK_Directories_Parents_ParentId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
