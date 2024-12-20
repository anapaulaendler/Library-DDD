using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infra.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Email).HasColumnName("E-mail").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Password).HasColumnName("Password").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Role).HasColumnName("Role").IsRequired();
    }
}
