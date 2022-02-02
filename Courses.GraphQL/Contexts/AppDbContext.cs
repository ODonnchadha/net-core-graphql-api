using Courses.GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses.GraphQL.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}
