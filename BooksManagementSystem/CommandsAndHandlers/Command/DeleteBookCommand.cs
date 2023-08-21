using MediatR;

namespace BooksManagementSystem.CommandsAndHandlers.Command
{
    public class DeleteBookCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
