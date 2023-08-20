using BooksManagementSystem.CommandsAndHandlers.Command;
using BooksManagementSystem.CommandsAndHandlers.Query;
using BooksManagementSystem.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagementSystem.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IMediator mediator;
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

        // POST: BooksController/Create
        [HttpPost("create")]
        public async Task<Book> CreateBook(CreateBookCommand createBookCommand)
        {
            var result = await mediator.Send(createBookCommand);
            return result;
        }

        // POST: BooksController/Edit/5
        [HttpPost("edit")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }

        // POST: BooksController/Delete/5
        [HttpDelete("delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }
    }
}
