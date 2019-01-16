using ExamCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Services
{
    public interface ISubject
    {
        IEnumerable<Subject> All { get; }
        Subject GetSubject(int? Id);
        void Add(Subject _Subject);
        void Remove(int? Id);
        void Edit(Subject _Subject);
    }
}
