using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Models
{
    public class ResultDetail
    {
        public virtual int Id { get; set; }
        public virtual int ResultId { get; set; }
        public virtual Result Result { get; set; }
        public virtual int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual bool IsRight { get; set; }
    }
}
