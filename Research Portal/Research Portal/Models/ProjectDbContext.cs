using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Research_Portal.Models
{
    public class ProjectDbContext : DbContext 
    {

        public ProjectDbContext() : base("name=ProjectDBConnectionString") { }

        public DbSet<Author> Author { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<Research> Research { get; set; }
        public DbSet<ResearchAuthor> ResearchAuthor { get; set; }
        public DbSet<School> School { get; set; }

    }
}