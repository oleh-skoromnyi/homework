using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class DirectoryPermission
    {
        public int UserId { get; set; }
        public int DirectoryId { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public virtual User User { get; set; }
        public virtual Directory Directory { get; set; }
    }
}
