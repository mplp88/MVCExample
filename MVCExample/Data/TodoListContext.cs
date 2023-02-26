using Microsoft.EntityFrameworkCore;
using MVCExample.Models;

namespace MVCExample.Data
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options)
            : base(options)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
