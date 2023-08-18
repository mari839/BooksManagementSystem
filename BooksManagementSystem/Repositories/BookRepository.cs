using BooksManagementSystem.DbContexts;
using BooksManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookDbContext;
        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public async Task<Book> CreateBook(Book book)
        {
            var result = _bookDbContext.Books.Add(book);
            await _bookDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> deleteBook(int id)
        {
            var filteredData = _bookDbContext.Books.Where(x => x.Id.Equals(id)).FirstOrDefault();
            _bookDbContext.Books.Remove(filteredData);
            return await _bookDbContext.SaveChangesAsync();
        }

        public async  Task<Book> getBookById(int id)
        {
            return await _bookDbContext.Books.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> getBooksList()
        {
            var result = await _bookDbContext.Books.OrderBy(b=>b.Id).ToListAsync();
            return result;
        }

        public async Task<int> updateBook(Book book)
        {
            _bookDbContext.Books.Update(book);
            return await _bookDbContext.SaveChangesAsync();
        }
    }
}
