using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DatabaseContext : DbContext
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
