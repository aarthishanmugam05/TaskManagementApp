using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Model;

namespace TaskManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
