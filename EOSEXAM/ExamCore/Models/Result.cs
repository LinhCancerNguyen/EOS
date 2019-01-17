using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Models
{
    public class Result
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual float Mark { get; set; }
        public virtual IList<ResultDetail> ResultDetails { get; set; }
    }
}
