using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Data;
using ExamOnline.Models;
using ExamOnline.Services;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class QuestionRepository : IQuestion
    {
        private ExamDBContext Db = null;

        public QuestionRepository(ExamDBContext _Db)
        {
            Db = _Db;
        }

        public IEnumerable<Question> All => Db.Question;

        public void Add(Question _Question)
        {
            Db.Question.Add(_Question);
            Db.SaveChanges();
        }

        public void Edit(Question _Question)
        {
            Db.Entry(_Question).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public IEnumerable<Question> GetQuestion()
        {
            IQueryable<Question> questions = Db.Question
                   .Select(q => new Question
                   {
                       QuestionID = q.QuestionID,
                       QuestionContent = q.QuestionContent,
                       SubjectId = q.SubjectId,
                       Subject = Db.Subject.Where(s => s.SubjectId == q.SubjectId)
                       .Select(s => new Subject
                       {
                           SubjectId = s.SubjectId,
                           SubjectName = s.SubjectName,
                           SubjectCode = s.SubjectCode
                       }).First(),
                       Options = q.Options.Select(o => new Option
                       {
                           OptionId = o.OptionId,
                           OptionContent = o.OptionContent
                       }).ToList(),
                       Answers = Db.Answer.Where(a => a.QuestionID == q.QuestionID)
                       .Select(a => new Answer
                       {
                           AnswerId = a.AnswerId,
                           AnswerContent = a.AnswerContent,
                           QuestionID = a.QuestionID,
                           Question = q
                       }).ToList()
                   }).OrderByDescending(c => c.QuestionID).AsQueryable();
            return questions;
        }

        public Question GetQuestionById(int? Id)
        {
            var question = from q in Db.Question
                       join s in Db.Subject
                       on q.SubjectId equals s.SubjectId
                       where q.QuestionID == Id
                       select new Question
                       {
                           QuestionID = q.QuestionID,
                           QuestionContent = q.QuestionContent,
                           SubjectId = s.SubjectId,
                           Subject = s,
                           Options = q.Options.Select(o => new Option
                           {
                               OptionId = o.OptionId,
                               OptionContent = o.OptionContent
                           }).ToList(),
                           Answers = Db.Answer.Where(a => a.QuestionID == q.QuestionID)
                       .Select(a => new Answer
                       {
                           AnswerId = a.AnswerId,
                           AnswerContent = a.AnswerContent,
                           QuestionID = a.QuestionID,
                           Question = q
                       }).ToList()
                       };
            return question.First();
        }

        public IQueryable<Question> GetQuestionBySubjectName(string SubjectName)
        {
            IQueryable<Question> questions = Db.Question.Where(q => q.Subject.SubjectName == SubjectName)
                   .Select(q => new Question
                   {
                       QuestionID = q.QuestionID,
                       QuestionContent = q.QuestionContent,
                       Options = q.Options.Select(o => new Option
                       {
                           OptionId = o.OptionId,
                           OptionContent = o.OptionContent
                       }).ToList(),
                       Answers = Db.Answer.Where(a => a.QuestionID == q.QuestionID)
                       .Select(a => new Answer
                       {
                           AnswerId = a.AnswerId,
                           AnswerContent = a.AnswerContent,
                           QuestionID = a.QuestionID,
                           Question = q
                       }).ToList()
                   }).AsQueryable();
            return questions;
        }

        public void Remove(int? Id)
        {
            var question = GetQuestionById(Id);
            Db.Question.Remove(question);
            Db.SaveChanges();
        }
    }
}
