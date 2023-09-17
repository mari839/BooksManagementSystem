using BooksManagementSystem.Entities;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Command
{
    public class EditBookCommand : IRequest<int>
    {
        public EditBookCommand(int id, string isbn, string title, int publicationYear, string description, int rating) //can't change authorId
        {
            Id = id;
            Title = title;
            PublicationYear = publicationYear;
            Description = description;
            Rating = rating;
            ISBN = isbn;
        }

        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
