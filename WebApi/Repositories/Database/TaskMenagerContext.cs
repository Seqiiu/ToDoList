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
        public DbSet<User2Model> User2s { get; set; }
        public DbSet<StatusModel> Statuses { get; set; }
        public DbSet<ImageModel> Images { get; set; }
    }
}

