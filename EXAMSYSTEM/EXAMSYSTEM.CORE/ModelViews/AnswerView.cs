using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.CORE.ModelViews
{
    public class AnswerView
    {
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public string YourAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
