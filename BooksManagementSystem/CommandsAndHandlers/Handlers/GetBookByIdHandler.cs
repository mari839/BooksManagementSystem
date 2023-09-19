
using BooksManagementSystem.CommandsAndHandlers.Query;
using BooksManagementSystem.DTOs;
using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.Id);
            var booktoReturn = new BookDto();
            if (book != null)
            {
                booktoReturn = new BookDto
                {
                    Id = book.Id,
                    ISBN = book.ISBN,
                    Description = book.Description,
                    Author = new AuthorDto
                    {
                        Age = book.Author.Age,
                        Country = book.Author.Country,
                        FirstName = book.Author.FirstName,
                        Id = book.Author.Id,
                        LastName = book.Author.LastName,

                    },
                    AuthorId = book.AuthorId,
                    Title = book.Title,
                    PublicationYear = book.PublicationYear,
                    Rating = book.Rating,

                };
            }
            else
            {
                cancellationToken.ThrowIfCancellationRequested();
            }
            return booktoReturn;
        }
    }
}
