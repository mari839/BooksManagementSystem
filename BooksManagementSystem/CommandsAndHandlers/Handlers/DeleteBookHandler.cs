using BooksManagementSystem.CommandsAndHandlers.Command;
using BooksManagementSystem.Repositories;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.getBookById(request.Id);
            if (book == null)
            {
                return 0;
            }
            else
            {
                return await _bookRepository.deleteBook(request.Id);
            }
        }
    }
}
