using ExamCore.Models;
using ExamCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Repositories
{
    public class SubjectRepository : ISubject
    {
        public IEnumerable<Subject> All => throw new NotImplementedException();

        public void Add(Subject _Subject)
        {
            throw new NotImplementedException();
        }

        public void Edit(Subject _Subject)
        {
            throw new NotImplementedException();
        }

        public Subject GetSubject(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
