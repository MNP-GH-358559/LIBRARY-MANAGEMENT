using MAchineTest.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace MAchineTest.Data
{
    public class ApplicationDbContext:DbContext
    {
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Auther> authers { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { get; set; }




    }
}
