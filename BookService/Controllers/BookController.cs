using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.Database;
using BookService.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Book>> Get()
        {
            return await dbContext.Books.ToListAsync();
        }

        // GET api/book/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        // POST api/book
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            try
            {
                dbContext.Books.Add(book);
                await dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/book/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            try
            {
                dbContext.Books.Update(book);
                await dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bookToRemove = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
                if (bookToRemove == null)
                    return StatusCode(StatusCodes.Status204NoContent);
                dbContext.Books.Remove(bookToRemove);
                await dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, bookToRemove);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("reserved/{id}")]
        public async Task<bool> GetIsBookReserved(int id)
        {
            return (await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id)).IsReserved;
        }
    }
}
