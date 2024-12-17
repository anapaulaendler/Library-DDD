using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infra.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Author).HasColumnName("Author").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Isbn).HasColumnName("ISBN").HasMaxLength(10).IsFixedLength().IsRequired();
        builder.Property(x => x.Genre).HasColumnName("Genre").HasMaxLength(20).IsRequired();
        builder.Property(x => x.PublicationYear).HasColumnName("Publication Year").HasMaxLength(4).IsFixedLength().IsRequired();
        builder.Property(x => x.IsBorrowed).HasColumnName("Borrowed").IsRequired();
    }
}
