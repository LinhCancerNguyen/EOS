using System;
using System.Collections.Generic;
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
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public Nullable<int> SubjectId { get; set; }

        public Subject Subject { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}
