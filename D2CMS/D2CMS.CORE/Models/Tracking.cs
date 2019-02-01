using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.CORE.Models
{
    public class Tracking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ActionContent { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
