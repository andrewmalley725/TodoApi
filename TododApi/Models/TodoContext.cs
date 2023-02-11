using System;
using Microsoft.EntityFrameworkCore;

namespace TododApi.Models
{
	
        public class TodoContext : Microsoft.EntityFrameworkCore.DbContext
        {
            public TodoContext(DbContextOptions<TodoContext> options)
                : base(options)
            { }

            public DbSet<Todo> TodoList { get; set; }
            public DbSet<User> User { get; set; }

            protected override void OnModelCreating(ModelBuilder mb)
            {
                mb.Entity<User>().HasData(
                    new User
                    {
                        userId = 1,
                        username = "patrickStar2023"
                        
                    }
                    );
                mb.Entity<Todo>().HasData(
                    new Todo
                    {
                        todoId = 1,
                        userId = 1,
                        description = "Sleep under my rock",
                        done = false
                    }
                    );
            }

        
    }
}

