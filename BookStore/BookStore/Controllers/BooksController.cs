using BookStore.Domain;
using BookStore.Domain.Commands;
using BookStore.Domain.Contracts.Workflows;
using BookStore.Domain.Validation.Exception;
using BookStore.Domain.Workflows;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksWorklflow _booksWorkflow;

        public BooksController(IBooksWorklflow booksWorkflow)
        {
            _booksWorkflow = booksWorkflow;
        }

        [HttpGet]
        public IActionResult All()
        {
            var books = _booksWorkflow.AllOrderedByName();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Find([FromRoute] Guid id)
        {
            Book book = _booksWorkflow.Find(id);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Add([FromBody] BookCommand bookCommand)
        {
            try
            {
                _booksWorkflow.Add(bookCommand);
                return Ok();
            }
            catch (ValidationException v)
            {
                return BadRequest(v.Errors);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] BookCommand bookCommand)
        {
            try
            {
                _booksWorkflow.Update(id, bookCommand);
                return Ok();
            }
            catch (ValidationException v)
            {
                return BadRequest(v.Errors);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Remove([FromRoute] Guid id)
        {
            _booksWorkflow.Remove(id);
            return Ok();
        }
    }
}
