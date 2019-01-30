using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Data;
using ExamOnline.Models;
using ExamOnline.Services;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Repositories
{
    public class OptionRepository : IOption
    {
        private ExamDBContext Db = null;

        public OptionRepository(ExamDBContext _Db)
        {
            Db = _Db;
        }
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

        public IEnumerable<Option> GetAll()
        {
            throw new NotImplementedException();
        }

        public Option GetOption(int? Id)
        {
            var option = from o in Db.Option
                         join q in Db.Question
                         on o.QuestionID equals q.QuestionID
                         where o.OptionId == Id
                         select new Option{
                             OptionId = o.OptionId,
                             OptionContent = o.OptionContent,
                             QuestionID = o.QuestionID,
                             Question = q
                         };
            return option.FirstOrDefault();
        }

        public void Remove(int? Id)
        {
            Db.Remove(Db.Option.Find(Id));
            Db.SaveChanges();
        }
    }
}
