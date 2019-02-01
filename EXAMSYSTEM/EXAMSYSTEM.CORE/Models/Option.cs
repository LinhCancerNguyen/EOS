using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.CORE.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionConent { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
