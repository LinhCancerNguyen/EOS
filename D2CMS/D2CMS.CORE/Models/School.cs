using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace D2CMS.CORE.Models
{
    public class School
    {
        public int Id { get; set; }    
        [Required(ErrorMessage= "Field name needs a value!")]
        [StringLength(200, ErrorMessage ="Size false")]
        public string Name { get; set; }
        [Range(0,10,ErrorMessage ="Status is out range!")]
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
