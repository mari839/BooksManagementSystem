using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using BooksManagementSystem.Repositories;
using BooksManagementSystem.Entities;
using BooksManagementSystem.DbContexts;
using BooksManagementSystem.CommandsAndHandlers.Handlers;
using System.Security.Cryptography.X509Certificates;
using BooksManagement.Test.Services;

namespace BooksManagement.Test
{
    public class CreateBookTests
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookTests()
        {
            _bookRepository = new BookTestDataRepositoty();
        }

        [Fact]
        public async Task CreateBook_EveryFieldIsProvided()
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
            var result = _bookRepository.getBookById(book.Id).Result;

            // Assert
            Assert.Equal(book.Title, result.Title);
        }
    }
}
