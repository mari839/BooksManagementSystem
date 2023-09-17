using BooksManagementSystem.DTOs;
using BooksManagementSystem.Entities;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Query
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public int Id { get; set; } 
    }
}
