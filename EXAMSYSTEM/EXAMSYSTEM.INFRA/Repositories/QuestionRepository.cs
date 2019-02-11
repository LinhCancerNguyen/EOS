using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.INFRA.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXAMSYSTEM.INFRA.Repositories
{
    public class QuestionRepository: RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Question GetDetailById(int Id)
        {
            var question = (from q in this.DbContext.Questions
                            join s in this.DbContext.Subjects
                            on q.SubjectId equals s.SubjectId
                            where q.QuestionId == Id
                            select new Question
                            {
                                QuestionId = q.QuestionId,
                                QuestionContent = q.QuestionContent,
                                Option1 = q.Option1,
                                Option2 = q.Option2,
                                Option3 = q.Option3,
                                Option4 = q.Option4,
                                Answer = q.Answer,
                                SubjectId = s.SubjectId,
                                Subject = s
                            }).FirstOrDefault();
            return question;
        }

        public IEnumerable<Question> GetQuestions()
        {
            var questions = (from q in this.DbContext.Questions
                             join s in this.DbContext.Subjects
                             on q.SubjectId equals s.SubjectId
                             select new Question
                             {
                                 QuestionId = q.QuestionId,
                                 QuestionContent = q.QuestionContent,
                                 Option1 = q.Option1,
                                 Option2 = q.Option2,
                                 Option3 = q.Option3,
                                 Option4 = q.Option4,
                                 Answer = q.Answer,
                                 SubjectId = s.SubjectId,
                                 Subject = s
                             }).ToList();
            return questions;
        }
    }
    
    public interface IQuestionRepository:IRepository<Question>
    {
        Question GetDetailById(int Id);
        IEnumerable<Question> GetQuestions();
    } 
}
