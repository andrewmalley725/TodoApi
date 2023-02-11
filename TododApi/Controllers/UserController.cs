using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TododApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TododApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly TodoContext _db;

        public UserController(TodoContext context)
        {
            _db = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _db.User.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<User>> Get(int id)
        {
            return await _db.User.Where(x => x.userId == id).ToListAsync();
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody]User body)
        {
            User newUser = new User
            {
                userId = body.userId,
                username = body.username
            };

            _db.User.Add(newUser);
            await _db.SaveChangesAsync();
            return Ok("Added!");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

