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
        public IQueryable<Book> Books => _bookDbContext.Books.AsQueryable();

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

        public async Task<Book> getBookById(int id)
        {
            var book = await _bookDbContext.Books.Where(x => x.Id.Equals(id)).Include(a => a.Author).FirstOrDefaultAsync();
            return book;
        }

        public async Task<List<Book>> getBooksList()
        {
            var result = await _bookDbContext.Books.OrderBy(b => b.Id).Include(a => a.Author).ToListAsync();
            return result;
        }

        public async Task<int> updateBook(Book book)
        {
            int a = 0;

            if (book != null)
            {

                _bookDbContext.Books.Update(book);
            }

            a = await _bookDbContext.SaveChangesAsync();

            return a;
        }



        public async Task<List<Book>> searchBook(string? searchString, int? searchId, int? searchByPublicationYear)
        {

            IQueryable<Book> bookquer = _bookDbContext.Books;

            if (!string.IsNullOrEmpty(searchString))
            {
                bookquer = bookquer.Where(f => f.Title == searchString || f.ISBN == searchString).Include(a => a.Author);

            }
            else if (searchId != null)
            {
                bookquer = bookquer.Where(f => f.AuthorId == searchId).Include(a => a.Author);
            }
            else if (searchByPublicationYear != null)
            {
                bookquer = bookquer.Where(f => f.PublicationYear == searchByPublicationYear).Include(a => a.Author);
            }
            else
            {
                return null;
            }
            return await bookquer.ToListAsync();
        }
    }
}
