using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Data;
using ExamOnline.Models;
using ExamOnline.ModelsView;
using ExamOnline.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IEnumerable<Subject> All => Db.Subject.OrderByDescending(c => c.SubjectId);

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

        public IEnumerable<SelectListItem> GetAll()
        {
            var subjects = Db.Subject.Select(s => new SelectListItem
            {
                Text = s.SubjectName,
                Value = s.SubjectId.ToString()

            }).OrderByDescending(c => c.Value);

            return subjects;
        }

        public IEnumerable<SubjectVM> GetAllSubject()
        {
            var subjects = Db.Subject.Select(s => new SubjectVM
            {
                SubjectId = s.SubjectId,
                SubjectName = s.SubjectName
            }).OrderByDescending(c => c.SubjectId);
            return subjects;
        }

        public Subject GetSubject(int? Id)
        {
            var subject = Db.Subject.Where(s => s.SubjectId == Id).Select(s => new Subject
            {
                SubjectId = s.SubjectId,
                SubjectName = s.SubjectName,
                SubjectCode = s.SubjectCode
            }).FirstOrDefault();

            return subject;
        }

        public void Remove(int? Id)
        {
            Db.Subject.Remove(Db.Subject.Find(Id));
            Db.SaveChanges();
        }
    }
}
