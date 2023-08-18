using BooksManagementSystem.CommandsAndHandlers.Command;
using BooksManagementSystem.CommandsAndHandlers.Query;
using BooksManagementSystem.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagementSystem.Controllers
{
    public class BooksController : Controller
    {

        private IMediator mediator;
        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<Book> BookById(int id)
        {
            var employee = await mediator.Send(new GetBookByIdQuery() { Id = id});
            return employee;
        }

        [HttpPost]
        

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Book> CreateBook(Book book)
        {
            var result = await mediator.Send(new CreateBookCommand(book.ISBN, book.AuthorId, book.Title, book.PublicationYear, book.Description, book.Rating));
            return result;
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
