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

            //check if author id exist, if it doesn't exist it can be created 
            var bookWithAuthorId = await _bookRepository.searchBook(null, request.AuthorId, null);
            var book1 = new Book();
            foreach (var i in bookWithAuthorId)
            {
                if (request.AuthorId == i.AuthorId)
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
                    book1 = await _bookRepository.CreateBook(book);
                }
                else
                {
                    return book1;
                }
            }
            if (book1.Id == 0)
            {
                return null;
            }
            return book1;
        }
    }
}
