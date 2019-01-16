using ExamCore.Models;
using ExamCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Repositories
{
    public class ResultRepository : IResult
    {
        public IEnumerable<Result> All => throw new NotImplementedException();

        public void Add(Result _Result)
        {
            throw new NotImplementedException();
        }

        public void Edit(Result _Result)
        {
            throw new NotImplementedException();
        }

        public Result GetResult(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
