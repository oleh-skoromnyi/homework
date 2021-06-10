using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<FilePermission> FilePermissions { get; set; }
        public ICollection<DirectoryPermission> DirectoryPermissions { get; set; }
    }
}
