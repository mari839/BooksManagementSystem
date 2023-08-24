using BooksManagementSystem.Entities;

namespace BooksManagementSystem.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public AuthorDto Author { get; set; }

    }
}
