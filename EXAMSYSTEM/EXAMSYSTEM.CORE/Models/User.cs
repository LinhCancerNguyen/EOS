using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.CORE.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<UserExam> UserExams { get; set; }
    }
}
