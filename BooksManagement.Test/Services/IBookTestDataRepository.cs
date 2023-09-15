using BooksManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagement.Test.Services
{
    public interface IBookTestDataRepository
    {
        Book getBookByIdTest(int id);
        List<Book?> getBooksListTest();
        List<Book> searchBookByQuery(string query);
    }
}
