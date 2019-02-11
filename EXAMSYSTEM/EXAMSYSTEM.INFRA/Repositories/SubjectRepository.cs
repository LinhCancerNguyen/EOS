using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.CORE.ModelViews;
using EXAMSYSTEM.INFRA.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXAMSYSTEM.INFRA.Repositories
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IEnumerable<SelectListItem> GetAllSubjects()
        {
            var subjects = this.DbContext.Subjects.Select(s => new SelectListItem
            {
                Text = s.SubjectName,
                Value = s.SubjectId.ToString()

            }).OrderByDescending(c => c.Value);

            return subjects;
        }
    }

    public interface ISubjectRepository : IRepository<Subject>
    {
        IEnumerable<SelectListItem> GetAllSubjects();
    }
}
