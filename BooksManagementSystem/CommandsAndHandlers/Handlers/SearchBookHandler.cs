using BooksManagementSystem.CommandsAndHandlers.Query;
using BooksManagementSystem.DTOs;
using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BooksManagementSystem.CommandsAndHandlers.Handlers
{
    public class SearchBookHandler : IRequestHandler<SearchByQuery, List<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        public SearchBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookDto>> Handle(SearchByQuery request, CancellationToken cancellationToken)
        {


            BookDto booktoReturn = new BookDto();


            var books = await _bookRepository.searchBook(request.searchByQuery, request.searchById, request.searchByPublicationYear);
            List<BookDto> result = new List<BookDto>();

            if (!result.Any())
            {
                return null;
            }
            foreach (var book in books)
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
