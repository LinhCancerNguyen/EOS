using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.ModelsView
{
    public class QuestionVM
    {
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public string QuestionType { get; set; }
        public string Anwser { get; set; }
        public ICollection<OptionVM> Options { get; set; }
    }
}
