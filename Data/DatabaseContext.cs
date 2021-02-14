using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext() : base()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
