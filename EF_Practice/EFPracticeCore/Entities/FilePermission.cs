using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class FilePermission
    {
        public int UserId { get; set; }
        public int FileId { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public virtual User User { get; set; }
        public virtual File File { get; set; }
    }
}
