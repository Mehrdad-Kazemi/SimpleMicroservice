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
        DatabaseContext databaseContext;
        public UserController()
        {
            databaseContext = new DatabaseContext();
        }

        // GET: api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return databaseContext.Users.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return databaseContext.Users.Find(id);
        }

        // POST api/user
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            try
            {
                databaseContext.Users.Add(model);
                databaseContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // todo
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // todo
        }
    }
}
