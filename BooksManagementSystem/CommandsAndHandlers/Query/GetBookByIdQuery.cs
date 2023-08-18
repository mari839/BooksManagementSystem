using BooksManagementSystem.Entities;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Query
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; } 
    }
}
