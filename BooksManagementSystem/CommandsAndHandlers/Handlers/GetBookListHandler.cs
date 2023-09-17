using BooksManagementSystem.CommandsAndHandlers.Query;
using BooksManagementSystem.DTOs;
using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using MediatR;
using System.Text.Json;

namespace BooksManagementSystem.CommandsAndHandlers.Handlers
{
    public class GetBookListHandler : IRequestHandler<GetBookListQuery, List<BookDto>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookListHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookDto>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksList();
            List<BookDto> result = new List<BookDto>();

            foreach (var book in books)
            {

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
                        BookNamesList = book.Author.Books.Select(x => x.Title).ToList(),
                    },
                    AuthorId = book.AuthorId,
                    Title = book.Title,
                    PublicationYear = book.PublicationYear,
                    Rating = book.Rating,
                };

                result.Add(booktoReturn);
                
            }
            return result;
        }
    }
}

