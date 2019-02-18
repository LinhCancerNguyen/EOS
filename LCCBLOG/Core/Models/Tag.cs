using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Tag
    {
        public virtual int TagId { get; set; }
        public virtual string Name { get; set; }
        public virtual string UrlSlug { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<PostTag> PostTags { get; set; }
    }
}
