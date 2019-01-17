using ExamCore.Data;
using ExamCore.Models;
using ExamCore.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Repositories
{
    public class QuestionRepository : IQuestion
    {
        private ExamDB Db = null;

        public QuestionRepository(ExamDB _Db)
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

        public Question GetQuestion(int? Id)
        {
            return Db.Question.Find(Id);
        }

        public void Remove(int? Id)
        {
            Db.Question.Remove(Db.Question.Find(Id));
            Db.SaveChanges();
        }
    }
}
