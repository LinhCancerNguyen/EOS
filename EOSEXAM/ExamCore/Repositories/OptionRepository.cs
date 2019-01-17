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
    public class OptionRepository : IOption
    {
        private ExamDB Db = null;

        public OptionRepository(ExamDB _Db)
        {
            Db = _Db;
        }

        public IEnumerable<Option> All => Db.Option;

        public void Add(Option _Option)
        {
            Db.Option.Add(_Option);
            Db.SaveChanges();
        }

        public void Edit(Option _Option)
        {
            Db.Entry(_Option).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Option GetOption(int? Id)
        {
            return Db.Option.Find(Id);
        }

        public void Remove(int? Id)
        {
            Db.Option.Remove(Db.Option.Find(Id));
            Db.SaveChanges();
        }
    }
}
