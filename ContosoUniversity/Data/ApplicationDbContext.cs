using ContosoUniversity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>()
                .Property(c => c.CourseId)
                .ValueGeneratedNever();

            base.OnModelCreating(builder);
        }

        public DbSet<ContosoUniversity.Entities.Student> Student { get; set; }
    }
}
