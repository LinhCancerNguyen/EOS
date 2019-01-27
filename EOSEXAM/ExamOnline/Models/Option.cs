using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionContent { get; set; }
        public Nullable<int> QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
