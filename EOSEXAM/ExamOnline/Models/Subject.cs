using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    public class Subject
    {
        public Subject()
        {
            this.Questions = new HashSet<Question>();
        }
        public int SubjectId { get; set; }
        [Required]
        [Display(Name = "Subject")]
        public string SubjectName { get; set; }
        [Required]
        [Display(Name = "Code")]
        public string SubjectCode { get; set; }
        public ICollection<Question> Questions { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ListOfSubject { get; set; }
    }
}
