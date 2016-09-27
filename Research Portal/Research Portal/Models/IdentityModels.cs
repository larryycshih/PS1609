using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Research_Portal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<Research> Research { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<ResearchAuthor> ResearchAuthor { get; set; }
    }
}