using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.CORE.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Option> Options { get; set; }

    }
}
