using ExamCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Services
{
    public interface IQuestion
    {
        IEnumerable<Question> All { get; }
        Question GetQuestion(int? Id);
        void Add(Question _Question);
        void Remove(int? Id);
        void Edit(Question _Question);
    }
}
