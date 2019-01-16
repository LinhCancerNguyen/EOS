using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Models
{
    public class Question
    {
        public virtual int Id { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual string Content { get; set; }
    }
}
