using BooksManagementSystem.DTOs;
using BooksManagementSystem.Entities;
using MediatR;
using System.Collections.Generic;

namespace BooksManagementSystem.CommandsAndHandlers.Query
{
    public class GetBookListQuery : IRequest<List<BookDto>>
    {
        
    }
}
