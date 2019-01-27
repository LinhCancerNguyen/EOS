using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.ModelsView
{
    public class QuizAnswerVM
    {
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public string YourAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
