using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.CORE.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime OpenDate { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
