using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infra.Configurations;

internal class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans").HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.BookId).IsRequired();

        builder.Property(x => x.LoanDate).HasColumnName("Loan Date").IsRequired();
        builder.Property(x => x.DueDate).HasColumnName("Due Date").IsRequired();
        builder.Property(x => x.ReturnDate).HasColumnName("Return Date").IsRequired();
        builder.Property(x => x.Fine).HasColumnName("Fine").IsRequired();

        builder.HasOne(x => x.User).WithMany().IsRequired();
        builder.HasOne(x => x.Book).WithMany().IsRequired();
    }
}
