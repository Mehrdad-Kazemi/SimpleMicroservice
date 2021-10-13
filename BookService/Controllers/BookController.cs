using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.Database;
using BookService.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        DatabaseContext dbContext;

        public BookController()
        {
            dbContext = new DatabaseContext();
        }

        // GET: api/book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return dbContext.Books.ToList();
        }

        // GET api/book/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return dbContext.Books.FirstOrDefault(x => x.Id == id);
        }

        // POST api/book
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/book/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            try
            {
                dbContext.Books.Update(book);
                dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/book/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var bookToRemove = dbContext.Books.FirstOrDefault(x => x.Id == id);
                if (bookToRemove == null)
                    return StatusCode(StatusCodes.Status204NoContent);
                dbContext.Books.Remove(bookToRemove);
                dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, bookToRemove);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
