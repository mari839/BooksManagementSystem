using BooksManagement.Test.Services;
using BooksManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagement.Test.RepositoryTesting
{
    public class UpdateBookTest
    {
        private readonly IBookRepository _bookRepository;
        //private readonly IDisposable _disposed;
        public UpdateBookTest()
        {
            _bookRepository = new BookTestDataRepositoty();
        }

        [Fact]
        public void UpdateBook_ValidBook()
        {
            // Arrange
            int bookIdToUpdate = 2;

            var bookToUpdated = _bookRepository.GetBookById(bookIdToUpdate).Result;


            // Act
            bookToUpdated.Title = "testUpdated";
            _bookRepository.UpdateBook(bookToUpdated);

            var bookToCheck = _bookRepository.GetBookById(bookIdToUpdate);


            // Assert
            Assert.Equal(bookToUpdated.Title, bookToCheck.Result.Title);
        }
    }
}
