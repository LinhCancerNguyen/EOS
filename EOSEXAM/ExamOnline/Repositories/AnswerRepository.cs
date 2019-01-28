using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Data;
using ExamOnline.Models;
using ExamOnline.ModelsView;
using ExamOnline.Services;

namespace ExamOnline.Repositories
{
    public class AnswerRepository : IAnswer
    {
        private ExamDBContext Db = null;

        public AnswerRepository(ExamDBContext _Db)
        {
            Db = _Db;
        }

        public QuizAnswerVM GetAnswerByYourAnswer(QuizAnswerVM QuizAnswerVM)
        {
            QuizAnswerVM result = Db.Answer.Where(a => a.QuestionID == QuizAnswerVM.QuestionId).Select(a => new QuizAnswerVM
            {
                QuestionId = a.QuestionID.Value,
                YourAnswer = a.AnswerContent,
                IsCorrect = (QuizAnswerVM.YourAnswer.ToLower().Equals(a.AnswerContent.ToLower()))

            }).FirstOrDefault();
            return result;
        }
    }
}
