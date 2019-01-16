using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Core.Models
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int AuthorId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Author name has greater 3 characters and less 50 characters", MinimumLength = 3)]
        public string AuthorName { get; set; }

        [Display(Name = "Biography")]
        public string AuthorBio { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
