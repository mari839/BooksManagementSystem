using BooksManagement.Test.Services;
using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagement.Test.RepositoryTesting
{
    public class DeleteBookTest
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookTest()
        {
            _bookRepository = new BookTestDataRepositoty();
        }

        [Fact]
        public void DeleteBook_ExistingId()
        {
            // Arrange
            Book book = new Book();

            book.Title = "Title";
            book.Description = "Description";
            book.AuthorId = 1;
            book.PublicationYear = 1213;
            book.Rating = 10;
            book.ISBN = "Test";
            book.Id = 4;

            // Act
            _bookRepository.CreateBook(book);
            var result = _bookRepository.deleteBook(book.Id).Result;

            // Assert
            Assert.Equal(book.Id, result);
        }

        ////////////////////Handler testing
        //[Fact]
        //public void DeleteBook_NonExist()
        //{
        //    // Arrange
        //    Book book = new Book();

        //    book.Title = "Title";
        //    book.Description = "Description";
        //    book.AuthorId = 1;
        //    book.PublicationYear = 1213;
        //    book.Rating = 10;
        //    book.ISBN = "Test";
        //    book.Id = 4;

        //    // Act
        //    _bookRepository.CreateBook(book);
        //    var result = _bookRepository.deleteBook(7).Result;

        //    // Assert
        //    Assert.Throws<Exception>(()=>result);
        //}
    }
}
