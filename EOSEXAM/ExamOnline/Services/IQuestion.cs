using ExamOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Services
{
    public interface IQuestion
    {
        IQueryable<Question> GetQuestionBySubjectName(string SubjectName);
        IEnumerable<Question> GetQuestion();
        void Add(Question _Question);
    }
}
