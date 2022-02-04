using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
