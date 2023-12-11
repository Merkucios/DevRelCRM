using DevRelCRM.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevRelCRM.Infrastructure.Database.PostgreSQL
{
    // Класс контекста базы данных для PostgreSQL
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Применяет конфигурации из текущей сборки (PostgreSQL)
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Использует серийные столбцы для идентификации (для PostgreSQL)
            modelBuilder.UseSerialColumns();
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<User> Users { get; set; }
    }
}
