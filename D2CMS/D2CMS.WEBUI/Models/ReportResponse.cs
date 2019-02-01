using D2CMS.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D2CMS.WEBUI.Models
{
    public class ReportResponse
    {
        public User User { get; set; }
        public IEnumerable<Report> Reports { get; set; }
    }

    public class TeamReportResponse
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Report> Reports { get; set; }
        public DateTime TargetDate { get; set; }
    }
}
