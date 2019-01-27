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
    public class SubjectRepository: ISubject
    {
        private ExamDBContext Db = null;

        public SubjectRepository(ExamDBContext _Db)
        {
            Db = _Db;
        }

        public IEnumerable<Subject> All => Db.Subject;

        public void Add(Subject _Subject)
        {
            Db.Subject.Add(_Subject);
            Db.SaveChanges();
        }

        public void Edit(Subject _Subject)
        {
            Db.Entry(_Subject).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public Subject GetSubject(int? Id)
        {
            return Db.Subject.Find(Id);
        }

        public void Remove(int? Id)
        {
            Db.Subject.Remove(Db.Subject.Find(Id));
            Db.SaveChanges();
        }
    }
}
