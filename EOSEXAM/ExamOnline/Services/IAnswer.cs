using ExamOnline.Models;
using ExamOnline.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Services
{
    public interface IAnswer
    {
        QuizAnswerVM GetAnswerByYourAnswer(QuizAnswerVM YourAnswer);
    }
}
