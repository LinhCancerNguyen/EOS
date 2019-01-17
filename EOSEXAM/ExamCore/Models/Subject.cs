using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Models
{
    public class Subject
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual IList<Question> Questions {get; set;}
        public virtual IList<Result> Results { get; set; }
    }
}
