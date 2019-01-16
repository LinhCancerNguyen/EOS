using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Core.Models
{
    public partial class Book
    {
        public int BookId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "Book name has greater 3 characters and less 50 characters", MinimumLength = 3)]
        public string BookName { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        [Display(Name ="Image")]
        public string ImageUrl { get; set; }
        public string Synopsis { get; set; }

        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; }
        public string Review { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
    }
}
