using BooksManagementSystem.Entities;

namespace BooksManagementSystem.Repositories
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

        Task<List<Book>> GetBooksList(); //GET /api/books: Retrieve a paginated list of all books, with filtering and sorting options.
        Task<Book> GetBookById(int id); //GET /api/books/{id}: Retrieve details of a specific book by its ID.
        Task<Book> CreateBook(Book book); //POST /api/books: Create a new book.
        Task<int> UpdateBook(Book book); //PUT /api/books/{id}: Update the details of a specific book.
        Task<int> deleteBook(int id); //DELETE /api/books/{id}: Delete a specific book.
        //public Book searchByTitle(string title); //searches by title
        //public Book searchByAuthor(string author); 
        
        Task<List<Book>> SearchBook(string? searchString, int? searchId, int? searchByPublicationYear);

    }
}
