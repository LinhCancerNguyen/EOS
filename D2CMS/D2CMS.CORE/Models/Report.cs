using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.CORE.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ReportDate { get; set; }
        public float Study { get; set; }
        public float Docs { get; set; }
        public float Coding { get; set; }
        public float TestCode { get; set; }
        public float FixBug { get; set; }
        public float TestBug { get; set; }
        public float Training { get; set; }
        public float Communication { get; set; }
        public float Manage { get; set; }
        public float Meeting { get; set; }        
        public float Reviewing { get; set; }
        public float Others { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public User User { get; set; }
    }
}
