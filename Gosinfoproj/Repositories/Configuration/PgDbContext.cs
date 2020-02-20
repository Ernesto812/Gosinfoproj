using Gosinfoproj.Models;
using Microsoft.EntityFrameworkCore;

namespace Gosinfoproj.Repositories.Configuration
{
    public class PgDbContext : DbContext
    {
        public PgDbContext(DbContextOptions<PgDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureDalToDo(builder);
        }

        private void ConfigureDalToDo(ModelBuilder builder)
        {
            builder.Entity<Employee>().HasKey(m => m.Id);
        }
    }

}
