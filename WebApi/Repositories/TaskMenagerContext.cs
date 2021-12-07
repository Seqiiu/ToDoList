using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class TaskMenagerContext : DbContext
    {
        public TaskMenagerContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TaskModel> Tasks { get; set; }

    }
}
