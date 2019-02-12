using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EXAMSYSTEM.CORE.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        [Display(Name ="Subject")]
        [Required(ErrorMessage = "Subject is required")]
        public string SubjectName { get; set; }
        [Display(Name = "Code")]
        [Required(ErrorMessage = "Code is required")]
        public string SubjectCode { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<UserExam> UserExams { get; set; }
    }
}
