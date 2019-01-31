using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    public class Question
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
            this.Options = new HashSet<Option>();
        }
        public int QuestionID { get; set; }
        [Required]
        [Display(Name = "Question")]
        public string QuestionContent { get; set; }
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}
