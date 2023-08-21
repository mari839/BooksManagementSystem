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

        [HttpGet]
        public async Task<List<Book>> BookList()
        {
            var employee = await mediator.Send(new GetBookListQuery());
            return employee;
        }

        [HttpGet("{id}")]
        public async Task<Book> BookById(int id)
        {
            var employee = await mediator.Send(new GetBookByIdQuery() { Id = id});
            return employee;
        }

        // POST: BooksController/Create
        [HttpPost("create")]
        public async Task<ActionResult<Book>> CreateBook(CreateBookCommand createBookCommand)
        {
            var result = await mediator.Send(createBookCommand);
            return Ok(result);
        }


        // POST: BooksController/Edit/5
        [HttpPut("edit")]
        public async Task<int> Edit(EditBookCommand editBookCommand)
        {
            var bookToReturn = await mediator.Send(editBookCommand);
            return bookToReturn;
        }

        [HttpDelete("id")]
        public async Task<int> Delete(int id)
        {
            return await mediator.Send(new DeleteBookCommand(){ Id = id});
        }
    }
}
