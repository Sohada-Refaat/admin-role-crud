using System;
using System.Collections.Generic;

namespace AdminRole.Models
{
    public partial class Role
    {
        public Role()
        {
            Admins = new HashSet<Admin>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
    }
}
