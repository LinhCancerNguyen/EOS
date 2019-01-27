using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamOnline.ModelsView
{
    public class SubjectVM
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public IEnumerable<SelectListItem> ListOfSubject { get; set; }
    }
}
