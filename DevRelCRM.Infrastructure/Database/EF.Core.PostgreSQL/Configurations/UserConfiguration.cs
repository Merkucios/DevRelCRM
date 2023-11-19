using DevRelCRM.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevRelCRM.Infrastructure.Database.PostgreSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Id).IsUnique();
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Surname).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Patronym).HasMaxLength(100); 
            builder.Property(t => t.NickName).HasMaxLength(100).IsRequired(); 
            builder.Property(t => t.Email).HasMaxLength(255).IsRequired();
            builder.HasIndex(t => t.Email).IsUnique();
            builder.Property(t => t.Password).HasMaxLength(255).IsRequired(); 
            builder.Property(t => t.Role).HasMaxLength(50); 
            builder.Property(t => t.DateAdded).IsRequired();

        }
    }
}
