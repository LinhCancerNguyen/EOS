using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EXAMSYSTEM.CORE.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Display(Name = "Question")]
        [Required(ErrorMessage = "Question is required")]
        public string QuestionContent { get; set; }
        [Display(Name = "Option 1")]
        [Required(ErrorMessage = "Option is required")]
        public string Option1 { get; set; }        
        [Display(Name = "Option 2")]
        [Required(ErrorMessage = "Option is required")]
        public string Option2 { get; set; }
        [Display(Name = "Option 3")]
        [Required(ErrorMessage = "Option is required")]
        public string Option3 { get; set; }
        [Display(Name = "Option 4")]
        [Required(ErrorMessage = "Option is required")]
        public string Option4 { get; set; }
        [Required(ErrorMessage = "Answer is required")]
        public string Answer { get; set; }
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

    }
}
