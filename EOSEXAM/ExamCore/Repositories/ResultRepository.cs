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
    public class ResultRepository : IResult
    {
        private ExamDB Db = null;

        public ResultRepository(ExamDB _Db)
        {
            Db = _Db;
        }

        public IEnumerable<Result> All => Db.Result;

        public void Add(Result _Result)
        {
            Db.Result.Add(_Result);
            Db.SaveChanges();
        }

        public void Edit(Result _Result)
        {
            Db.Entry(_Result).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Result GetResult(int? Id)
        {
            return Db.Result.Find(Id);
        }

        public void Remove(int? Id)
        {
            Db.Result.Remove(Db.Result.Find(Id));
            Db.SaveChanges();
        }
    }
}
