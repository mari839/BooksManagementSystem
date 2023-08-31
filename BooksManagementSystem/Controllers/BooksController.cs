using BooksManagementSystem.CommandsAndHandlers.Command;
using BooksManagementSystem.CommandsAndHandlers.Query;
using BooksManagementSystem.DTOs;
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
        public async Task<List<BookDto>> BookList()
        {
            var employee = await mediator.Send(new GetBookListQuery());

            return employee;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> BookById(int id)
        {
            var book = await mediator.Send(new GetBookByIdQuery() { Id = id });
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();

            }
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
        public async Task<ActionResult<int>> Edit(EditBookCommand editBookCommand)
        {

            var bookToReturn = await mediator.Send(editBookCommand);
            if(bookToReturn !=0)
            {

            return Ok(bookToReturn);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("id")]
        public async Task<int> Delete(int id)
        {
            return await mediator.Send(new DeleteBookCommand() { Id = id });
        }

        [HttpGet("search")]
        public async Task<ActionResult<BookDto>> getBookBySearchString(string? name, int? id, int? publicationYear)
        {

            var book = await mediator.Send(new SearchByQuery() { searchByQuery = name, searchById = id, searchByPublicationYear = publicationYear });
            if (book == null)
            {
                return NotFound();
            }
            else
            {

                return Ok(book);
            }
        }
    }
}
