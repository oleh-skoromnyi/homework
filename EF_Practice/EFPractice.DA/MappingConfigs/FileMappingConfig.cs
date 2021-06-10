using EFPractice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.DA.MappingConfigs
{
    public class FileMappingConfig : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("Files", "sch");

            builder.HasKey(x => x.Id);
                    //.HasName("PK_Files");
                    //.IsClustered();

            builder.Property(x => x.Title)
                    .HasMaxLength(128)
                    .IsUnicode();

            builder.Property(x => x.Extension)
                    .HasMaxLength(128)
                    .IsUnicode();

            builder.Property(x => x.Size)
                    .HasMaxLength(128)
                    .IsUnicode();

            builder.HasMany(x => x.FilePermissions)
                .WithOne(x => x.File)
                .HasForeignKey(x => x.FileId)
                .HasConstraintName("FK_FilePermissions_Files_FileId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Directory)
                 .WithMany(x => x.Files)
                 .HasForeignKey(x => x.DirectoryId)
                 .HasConstraintName("FK_Directories_Files_DirectoryId")
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

