using Microsoft.EntityFrameworkCore;
using TodoList.EntityConfigs;
using TodoList.Models;

namespace TodoList.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos => Set<Todo>();

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=Localhost;Database=TodoList;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TodoEntityConfig());
        }
    }
}