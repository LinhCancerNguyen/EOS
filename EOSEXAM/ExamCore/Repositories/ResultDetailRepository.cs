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
    public class ResultDetailRepository : IResultDetail
    {
        private ExamDB Db = null;

        public ResultDetailRepository(ExamDB _Db)
        {
            Db = _Db;
        }

        public IEnumerable<ResultDetail> All => Db.ResultDetail;

        public void Add(ResultDetail _ResultDetail)
        {
            Db.ResultDetail.Add(_ResultDetail);
            Db.SaveChanges();
        }

        public void Edit(ResultDetail _ResultDetail)
        {
            Db.Entry(_ResultDetail).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public ResultDetail GetResultDetail(int? Id)
        {
            return Db.ResultDetail.Find(Id);
        }

        public void Remove(int? Id)
        {
            Db.ResultDetail.Remove(Db.ResultDetail.Find(Id));
            Db.SaveChanges();
        }
    }
}
