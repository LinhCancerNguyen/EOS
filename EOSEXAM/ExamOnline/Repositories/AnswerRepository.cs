using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Data;
using ExamOnline.Models;
using ExamOnline.ModelsView;
using ExamOnline.Services;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class AnswerRepository : IAnswer
    {
        private ExamDBContext Db = null;

        public AnswerRepository(ExamDBContext _Db)
        {
            Db = _Db;
        }

        public void Add(Answer _Answer)
        {
            Db.Answer.Add(_Answer);
            Db.SaveChanges();
        }

        public void Edit(Answer _Answer)
        {
            Db.Entry(_Answer).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public IEnumerable<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Answer GetAnswer(int? Id)
        {
            var answer = from a in Db.Answer
                         join q in Db.Question
                         on a.QuestionID equals q.QuestionID
                         where a.AnswerId == Id
                         select new Answer
                         {
                             AnswerId = a.AnswerId,
                             AnswerContent = a.AnswerContent,
                             QuestionID = q.QuestionID,
                             Question = q
                         };
            return answer.FirstOrDefault();
        }

        public IEnumerable<Answer> GetAnswerByQuestionId(int? QuestionId)
        {
            var answers = from a in Db.Answer
                          where a.QuestionID == QuestionId
                          select a;
            return answers;
        }

        public QuizAnswerVM GetAnswerByYourAnswer(QuizAnswerVM QuizAnswerVM)
        {
            QuizAnswerVM result = Db.Answer.Where(a => a.QuestionID == QuizAnswerVM.QuestionId).Select(a => new QuizAnswerVM
            {
                QuestionId = a.QuestionID,
                QuestionContent = QuizAnswerVM.QuestionContent,
                YourAnswer = QuizAnswerVM.YourAnswer,
                IsCorrect = (QuizAnswerVM.YourAnswer.ToLower().Equals(a.AnswerContent.ToLower()))

            }).FirstOrDefault();
            return result;
        }

        public void Remove(int? Id)
        {
            Db.Remove(Db.Answer.Find(Id));
            Db.SaveChanges();
        }
    }
}
