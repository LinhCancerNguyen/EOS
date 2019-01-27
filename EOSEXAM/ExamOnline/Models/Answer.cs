using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerContent { get; set; }
        public Nullable<int> QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
