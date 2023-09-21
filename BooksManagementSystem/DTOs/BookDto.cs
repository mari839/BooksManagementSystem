using BooksManagementSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace BooksManagementSystem.DTOs
{
    public class BookDto
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Author Id is required")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Publication year is required")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }
        public AuthorDto Author { get; set; }

    }
}
