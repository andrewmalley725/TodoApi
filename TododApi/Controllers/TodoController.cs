using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TododApi.Models;
using static TododApi.Models.TodoContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TododApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {

        private readonly TodoContext _db;

        public TodoController(TodoContext context)
        {
            _db = context;
        }

        private static List<Dictionary<string, object>> FormatData(IEnumerable<Todo> data)
        {
            return data.Select(item => new Dictionary<string, object>
            {
                { "ID", item.todoId },
                { "Description", item.description },
                { "Username", item.User.username },
                { "Done", item.done }
            }).ToList();
        }

        // GET: api/values
        [HttpGet]
        public async Task<List<Dictionary<string, object>>> GetTodo()
        {

            List<Todo> dbItems = await _db.TodoList
                                       .Include(x => x.User)
                                       .ToListAsync();

            List<Dictionary<string, object>> data = FormatData(dbItems);

            return data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<List<Dictionary<string, object>>> Get(int id)
        {
            List<Todo> dbItems = await _db.TodoList
                                       .Include(x => x.User)
                                       .Where(x => x.userId == id)
                                       .ToListAsync();

            List<Dictionary<string, object>> data = FormatData(dbItems);

            return data;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody]Todo value)
        {
            Todo newItem = new Todo
            {
                todoId = value.todoId,
                User = await _db.User.FirstOrDefaultAsync(x => x.userId == value.userId),
                userId = value.userId,
                description = value.description

            };
            _db.TodoList.Add(newItem);
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

