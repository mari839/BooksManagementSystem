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
            var bookWithAuthorId = _bookRepository.searchBook(null, request.AuthorId, null);
            Book book1 = new Book();

            if (request.AuthorId == bookWithAuthorId.Id)
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
                book1 =  await _bookRepository.CreateBook(book);
            }
            else
            {
                throw new NullReferenceException();
            }
            return book1;
        }
    }
}
