using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Database;
using UserService.Database.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DatabaseContext dbContext;
        public UserController()
        {
            dbContext = new DatabaseContext();
        }

        // GET: api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return dbContext.Users.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return dbContext.Users.Find(id);
        }

        // POST api/user
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            try
            {
                dbContext.Users.Add(model);
                dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userToRemove = dbContext.Users.FirstOrDefault(x => x.Id == id);
                if (userToRemove == null)
                    return StatusCode(StatusCodes.Status204NoContent);
                dbContext.Users.Remove(userToRemove);
                dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, userToRemove);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
