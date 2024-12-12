using System;
using System.Collections.Generic;

namespace AdminRole.Models
{
    public partial class Admin
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}
