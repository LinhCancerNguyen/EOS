using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.CORE.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<UserExam> UserExams { get; set; }
    }
}
