using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class PostTag
    {
        public virtual int PostId { get; set; }
        public virtual int TagId { get; set; }
        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
