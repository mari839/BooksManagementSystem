using BooksManagementSystem.DTOs;
using BooksManagementSystem.Entities;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Query
{
    public class SearchByQuery : IRequest<List<BookDto>>
    {
        public string? searchByQuery { get; set; }
        public int? searchById { get; set; }

        public int? searchByPublicationYear { get; set; }
    }
}

