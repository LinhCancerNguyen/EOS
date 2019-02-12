using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EXAMSYSTEM.CORE.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [Display(Name = "Role")]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
