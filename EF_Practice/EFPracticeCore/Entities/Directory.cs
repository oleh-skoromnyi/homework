using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class Directory : Entity
    {
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public ICollection<DirectoryPermission> DirectoryPermissions { get; set; }
        public ICollection<File> Files { get; set; }
        public virtual Directory Parent { get; set; }
        public ICollection<Directory> Children { get; set; }
    }
}
