using BooksManagementSystem.CommandsAndHandlers.Query;
using BooksManagementSystem.DTOs;
using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BooksManagementSystem.CommandsAndHandlers.Handlers
{
    public class SearchBookHandler : IRequestHandler<SearchByQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        public SearchBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> Handle(SearchByQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.searchBook(request.searchBy);
            
                BookDto booktoReturn = new BookDto
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
                return booktoReturn;
            
        }
    }
}
