using BooksManagement.Test.Services;
using BooksManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagement.Test.RepositoryTesting
{
    public class GetBookListTest
    {
        private readonly IBookRepository _bookRepository;
        //private readonly IDisposable _disposed;
        public GetBookListTest()
        {
            _bookRepository = new BookTestDataRepositoty();
        }
        [Fact]
        public void GetBookList_IsNotNull()
        {

            var res = _bookRepository.GetBooksList().Result;

            Assert.NotNull(res);
        }
        [Fact]
        public void GetBookList_ReturnsAllBook()
        {
            var res = _bookRepository.GetBooksList();

            Assert.Equal(3, res.Result.Count());
        }



        //public void Dispose()
        //{
        //    // Clean up and dispose of the in-memory database context
        //    _disposed.Dispose();
        //}
    }
}
