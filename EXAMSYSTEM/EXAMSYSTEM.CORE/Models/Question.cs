using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.CORE.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Answer { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
