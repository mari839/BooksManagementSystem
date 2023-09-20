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
using Newtonsoft.Json;
using System.Net;
using System.Text;
using MySqlX.XDevAPI;

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
            var result = _bookRepository.GetBookById(book.Id).Result;

            // Assert
            Assert.Equal(book.Title, result.Title);


        }


        //[Fact]
        //public async void CreateBook_ExtraFieldIsProvided()
        //{
        //    //Arrange
        //    Book book = new Book();

            
        //    book.Title = "Title";
        //    book.Description = "Description";
        //    book.AuthorId = 1;
        //    book.PublicationYear = 1213;
        //    book.Rating = 10;
        //    book.ISBN = "Test";
        //    book.Id = 4;
            

        //    //act
            
        //    var res = _bookRepository.CreateBook(book);

        //    // Serialize the request data to JSON
        //    var jsonRequestData = JsonConvert.SerializeObject(book);

        //    // Create a JSON content from the serialized data
        //    var content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");

        //    // Act
        //    HttpClient client = new HttpClient();
        //    var response = await client.PostAsync("/api/books/create", content);

        //    // Assert
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    Assert.Throws();
        //}

        //[Fact]
        //public void CreateBook_FieldIsNotProvided()
        //{
        //    // Arrange
        //    Book book = new Book();

        //    book.Title = "Title";
        //    book.Description = "Description";
        //    book.AuthorId = 1;
        //    book.PublicationYear = 1213;
        //    book.Rating = 10;
        //    book.Id = 4;

        //    // Act
        //    _bookRepository.CreateBook(book);
        //    var result = _bookRepository.GetBookById(book.Id).Result;

        //    // Assert
        //    //Assert.Equal(book.Title, result.Title);
        //    Assert.IsAssignableFrom<Book>(result);
        //}
    }
}
