using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Please enter number of question")]
        [Display(Name ="Number of Question")]
        [Range(1, 10, ErrorMessage ="Number of question in range 1 : 10")]
        public int NumberOfQuestion { get; set; }
    }
}
