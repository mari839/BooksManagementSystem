using BooksManagementSystem.Entities;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Command
{
    public class CreateBookCommand : IRequest<Book>
    {
        public CreateBookCommand(string isbn, int authorId, string title, int publicationYear, string description, int rating)
        {
            ISBN = isbn;
            AuthorId = authorId;
            Title = title;
            PublicationYear = publicationYear;
            Description = description;
            Rating = rating;
        }

        
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
