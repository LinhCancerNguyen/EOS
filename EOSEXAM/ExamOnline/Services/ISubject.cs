using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamOnline.Services
{
    public interface ISubject
    {
        IEnumerable<Subject> All { get; }
        Subject GetSubject(int? Id);
        void Add(Subject _Subject);
        void Remove(int? Id);
        void Edit(Subject _Subject);
        IEnumerable<SelectListItem> GetAll();
    }
}
