using DevRelCRM.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevRelCRM.Infrastructure.Database.PostgreSQL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.UseSerialColumns();
            base.OnModelCreating(modelBuilder);

        }
    }
}
