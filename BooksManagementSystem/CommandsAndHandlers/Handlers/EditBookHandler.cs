using BooksManagementSystem.CommandsAndHandlers.Command;
using BooksManagementSystem.Repositories;
using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Handlers
{
    public class EditBookHandler : IRequestHandler<EditBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public EditBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<int> Handle(EditBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.Id);
            if (book == null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                
            }
            else
            {

                book.Id = request.Id;
                book.ISBN = request.ISBN;
                book.Title = request.Title;
                book.PublicationYear = request.PublicationYear;
                book.Description = request.Description;
                book.Rating = request.Rating;
            }
            return await _bookRepository.UpdateBook(book);
        }
    }
}
