using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class File : Entity
    {
        public int DirectoryId { get; set; }
        public string Title { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public virtual Directory Directory { get; set; }
        public ICollection<FilePermission> FilePermissions { get; set; }
    }
}
