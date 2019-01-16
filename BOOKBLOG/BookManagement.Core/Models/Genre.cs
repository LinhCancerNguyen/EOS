using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Core.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Book = new HashSet<Book>();
        }

        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Genre name has greater 3 characters and less 50 characters", MinimumLength = 3)]
        public string GenreName { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
