using BooksManagementSystem.CommandsAndHandlers.Command;
using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Handlers
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookHandler(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = new Book
            {
                ISBN = request.ISBN,
                AuthorId = request.AuthorId,
                Title = request.Title,
                PublicationYear = request.PublicationYear,
                Description = request.Description,
                Rating = request.Rating,
            };
            return await _bookRepository.CreateBook(book);
        }
    }
}
