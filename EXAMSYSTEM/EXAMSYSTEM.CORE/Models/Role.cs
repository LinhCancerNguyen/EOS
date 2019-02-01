using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.CORE.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public int RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
