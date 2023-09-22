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
    public class GetBookByIdTest
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByIdTest()
        {
            _bookRepository = new BookTestDataRepositoty();
        }

        [Fact]
        public void GetBookById_ExistingId_ReturnsCorrectBook()
        {
            // Arrange
            Book book = new Book();

            book.Title = "Title";
            book.Description = "Description";
            book.AuthorId = 1;
            book.PublicationYear = 1213;
            book.Rating = 10;
            book.ISBN = "Test";
            book.Id = 1;

            // Act
            var bookFromRep = _bookRepository.GetBookById(1);

            //Assert
            Assert.Equal(bookFromRep.Id, book.Id);
        }

        [Fact]
        public void GetBookById_NonExistingId_ReturnsNull()
        {
            // Arrange
            //Book book = new Book();

            //book.Title = "Title";
            //book.Description = "Description";
            //book.AuthorId = 1;
            //book.PublicationYear = 1213;
            //book.Rating = 10;
            //book.ISBN = "Test";
            //book.Id = 100;

            // Act
            var bookFromRep = _bookRepository.GetBookById(20);

            //Assert
            Assert.Null(bookFromRep.Result);
        }


    }
}
