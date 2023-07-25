using Calendar.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
namespace Calendar.DB
{
    public class TaskDBContext : DbContext
    {
        public DbSet<TaskEntity>? tasks { get; set; }
        public TaskDBContext(DbContextOptions<TaskDBContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>().ToTable("tasks");
        }
    }
}
