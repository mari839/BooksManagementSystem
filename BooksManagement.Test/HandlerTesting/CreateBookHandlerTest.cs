using BooksManagement.Test.Services;
using BooksManagementSystem.CommandsAndHandlers.Command;
using BooksManagementSystem.Entities;
using BooksManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagement.Test.HandlerTesting
{
    public class CreateBookHandlerTest
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookHandlerTest()
        {
            _bookRepository = new BookTestDataRepositoty();
        }

        [Fact]
        public void CreateBook_ValidInput_returnsCreater()
        {
            // Act
            var book = new Book();

            book.Title = "Title";
            book.Description = "Description";
            book.AuthorId = 1;
            book.PublicationYear = 1213;
            book.Rating = 10;
            book.ISBN = "Test";
            book.Id = 4;

            // Arrange
            
            var bookCreated= new CreateBookCommand("Test", 1, "Title", 1213, "Description", 10);


            // Assert 

            Assert.Equal(book.Title, bookCreated.Title);

        }

        [Fact]
        public void CreateBook_RequestIdMatches_ReturnsBook()
        {
            // Act
            var book = new Book();

            book.Title = "Title";
            book.Description = "Description";
            book.AuthorId = 1;
            book.PublicationYear = 1213;
            book.Rating = 10;
            book.ISBN = "Test";
            book.Id = 4;

            // Arrange
            

            // Assert
        }

    }
}
