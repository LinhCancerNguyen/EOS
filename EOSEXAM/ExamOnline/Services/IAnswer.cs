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
        IEnumerable<Answer> GetAll();
        Answer GetAnswer(int? Id);
        void Add(Answer _Option);
        void Remove(int? Id);
        void Edit(Answer _Option);
        IEnumerable<Answer> GetAnswerByQuestionId(int? QuestionId);
    }
}
