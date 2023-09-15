using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagement.Test.Services
{
    internal class BookTestDataRepositoty : IBookTestDataRepository
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

            _books = new List<Book> { book1, book2, book3 };

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

            _authors = new List<Author> { author1, author2 };
        }
        public List<Book> Books => throw new NotImplementedException();

        public Book getBookByIdTest(int id)
        {
            return _books.Where(b => b.Id == id).FirstOrDefault().GroupJoin(_authors, c => c.AuthorId, a => a.Id, (book, author) => new(book));
        }

        public List<Book?> getBooksListTest()
        {
            return _books.Join(_authors, b => b.AuthorId, a => a.Id, (book, author) => new(book)).ToList();
        }

        public List<Book> searchBookByQuery(string query)
        {
            return _books.ToList();
        }




        //public Task<Book> CreateBook(Book book)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> deleteBook(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Book getBookById(int id)
        //{
        //    return _books.FirstOrDefault(Books => Books.Id == id);
        //}

        //public Task<List<Book>> getBooksList()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<Book>> searchBook(string? searchString, int? searchId, int? searchByPublicationYear)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> updateBook(Book book)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
