using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        [Required]
        [Display(Name ="Answer")]
        public string AnswerContent { get; set; }
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
