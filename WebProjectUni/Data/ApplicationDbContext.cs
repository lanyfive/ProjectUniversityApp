using Microsoft.EntityFrameworkCore;
using WebProjectUni.Models;

namespace WebProjectUni.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CourseModel> Course { get; set; }
    }
}
