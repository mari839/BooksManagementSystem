using BooksManagementSystem.CommandsAndHandlers.Query;
using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Handlers
{
    public class GetBookListHandler : IRequestHandler<GetBookListQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookListHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<List<Book>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.getBooksList();
        }
    }
}
