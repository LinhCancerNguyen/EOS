using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        [Required]
        [Display(Name = "Option")]
        public string OptionContent { get; set; }
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
