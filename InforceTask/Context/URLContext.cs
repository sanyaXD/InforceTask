using Microsoft.EntityFrameworkCore;
using InforceTask.Models;

namespace InforceTask.Context
{
    public class URLContext:DbContext
    {
        public DbSet<URL>? Urls { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }

        public URLContext(DbContextOptions<URLContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
