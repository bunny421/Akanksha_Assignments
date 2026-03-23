using Microsoft.EntityFrameworkCore;
namespace CodeFirstEFinAsp.netcomdemo.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Author> authors { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Student> students { get; set; }

        public DbSet<Author1> authors1 { set; get; }

        public DbSet<Course1> courses1 { set; get; }

        public DbSet<Employee> employees { set; get; }

        public DbSet<UserDetail> userdetails { set; get; }
    }
}