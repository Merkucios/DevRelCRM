using DevRelCRM.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevRelCRM.Infrastructure.Database.PostgreSQL.Configurations
{
    // Конфигурация сущности User для Entity Framework Core
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        // Метод для настройки сущности User в базе данных
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.UserId);
            builder.HasIndex(t => t.UserId).IsUnique();
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Surname).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Patronym).HasMaxLength(100); 
            builder.Property(t => t.NickName).HasMaxLength(100).IsRequired(); 
            builder.Property(t => t.Email).HasMaxLength(255).IsRequired();
            builder.HasIndex(t => t.Email).IsUnique();
            builder.Property(t => t.Password).HasMaxLength(255).IsRequired(); 
            builder.Property(t => t.Role).HasMaxLength(50); 
            builder.Property(t => t.DateCreated).IsRequired();

        }
    }
}
