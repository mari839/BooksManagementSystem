using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksManagementSystem.Repositories;
using BooksManagementSystem.Entities;
using BooksManagementSystem.DbContexts;
using BooksManagementSystem.CommandsAndHandlers.Handlers;

namespace BooksManagement.Test
{
    public class CreateBookTests
    {
        [Fact]
        public void CreateBook_EveryFieldIsProvided()
        {
            //The arrange, act, assert pattern.
            //Arrange - setting up the test, initializing objects, getting a hold of test,dependencies of mocks.
            //Act - executing the actual test. executing method we want to test.
            //Assert - verifies that action we executed behaved as expected.


            //1.initialize mock repository
            //2.create test of CreateBook method and check if it returns valid book.
            var book = new Book()
            var bookHandler = new CreateBookHandler();
        }
    }
}
