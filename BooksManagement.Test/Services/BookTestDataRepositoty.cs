using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagement.Test.Services
{
    internal class BookTestDataRepositoty : IBookRepository
    {
        private List<Book> _books;
        private List<Author> _authors;

        public BookTestDataRepositoty()
        {
            var book1 = new Book()
            {
                Id = 1,
                Title = "Test",
                ISBN = "Test",
                AuthorId = 1,
                Description = "Test",
                PublicationYear = 1213,
                Rating = 10
            };
            var book2 = new Book()
            {
                Id = 2,
                Title = "Test",
                ISBN = "Test",
                AuthorId = 2,
                Description = "Test",
                PublicationYear = 1245,
                Rating = 10,
            };
            var book3 = new Book()
            {
                Id = 3,
                Title = "Test",
                ISBN = "Test",
                AuthorId = 2,
                Description = "Test",
                PublicationYear = 2345,
                Rating = 10,
            };


            var author1 = new Author()
            {
                Id = 1,
                Age = 1,
                Country = "Test",
                FirstName = "Test",
                LastName = "Test",
            };
            var author2 = new Author()
            {
                Id = 2,
                Age = 2,
                Country = "Test",
                FirstName = "Test",
                LastName = "Test",
            };

            book1.Author = author1;
            book2.Author = author2;

            _authors = new List<Author> { author1, author2 };
            _books = new List<Book> { book1, book2, book3 };

        }

        IQueryable<Book> IBookRepository.Books => _books.AsQueryable();

        public async Task<Book> CreateBook(Book book)
        {
            _books.Add(book);
            return book;

        }

        public async Task<int> deleteBook(int id)
        {
            var bookToDelete = await GetBookById(id);
            if (bookToDelete != null)
            {
                _books.Remove(bookToDelete);
                return bookToDelete.Id;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<Book>? GetBookById(int id)
        {
            var res = _books.Where(b => b.Id == id).FirstOrDefault();
            if (res == null)
            {
                return null;
            }
            else
            {
                return res;
            }
        }

        public async Task<List<Book>> GetBooksList()
        {
            return _books.ToList();
        }

        public async Task<List<Book>> SearchBook(string? searchString, int? searchId, int? searchByPublicationYear)
        {
            List<Book> booksToReturn = new List<Book>();
            if (!searchString.IsNullOrEmpty())
            {
                booksToReturn = _books.Where(b => b.Title == searchString || b.ISBN == searchString).ToList();
            }
            else if (searchId != null)
            {
                booksToReturn = _books.Where(b => b.Id == searchId.Value).ToList();
            }
            else if (searchByPublicationYear != null)
            {
                booksToReturn = _books.Where(b => b.PublicationYear == searchByPublicationYear).ToList();
            }
            else
            {
                return null;
            }
            return booksToReturn;
        }

        public async Task<int> UpdateBook(Book book)
        {
            var bookToDelete = await GetBookById(book.Id);
            _books.Remove(bookToDelete);
            _books.Add(book);
            return book.Id;
        }
    }
}
