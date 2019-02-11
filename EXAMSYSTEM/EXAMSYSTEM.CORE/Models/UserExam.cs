using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.CORE.Models
{
    public class UserExam
    {
        public int UserExamId { get; set; }
        public float Score { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public User User { get; set; }
        public Subject Subject { get; set; }
    }
}
