﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
        public int RoleId { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
