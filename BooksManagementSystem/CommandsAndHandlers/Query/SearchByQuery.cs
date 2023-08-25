using BooksManagementSystem.DTOs;
using BooksManagementSystem.Entities;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Query
{
    public class SearchByQuery : IRequest<BookDto>
    {
        public string searchBy { get; set; }
    }
}
