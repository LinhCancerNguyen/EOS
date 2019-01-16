using ExamCore.Models;
using ExamCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Repositories
{
    public class QuestionRepository : IQuestion
    {
        public IEnumerable<Question> All => throw new NotImplementedException();

        public void Add(Question _Question)
        {
            throw new NotImplementedException();
        }

        public void Edit(Question _Question)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
