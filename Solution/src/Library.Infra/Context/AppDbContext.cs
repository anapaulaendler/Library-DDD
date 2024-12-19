using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Library.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Loan> Loans { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var users = new[]
        {
            new User { Id = Guid.NewGuid(), Name = "Alice", Email = "alice@example.com", Role = Role.Member },
            new User { Id = Guid.NewGuid(), Name = "Bob", Email = "bob@example.com", Role = Role.Librarian },
            new User { Id = Guid.NewGuid(), Name = "Charlie", Email = "charlie@example.com", Role = Role.Admin },
            new User { Id = Guid.NewGuid(), Name = "Diana", Email = "diana@example.com", Role = Role.Member },
            new User { Id = Guid.NewGuid(), Name = "Eve", Email = "eve@example.com", Role = Role.Member }
        };

        modelBuilder.Entity<User>().HasData(users);

        var books = new[]
        {
            new Book { Id = Guid.NewGuid(), Title = "1984", Author = "George Orwell", Isbn = "9780451524935", Genre = "Dystopian", PublicationYear = "1949", IsBorrowed = false },
            new Book { Id = Guid.NewGuid(), Title = "To Kill a Mockingbird", Author = "Harper Lee", Isbn = "9780061120084", Genre = "Fiction", PublicationYear = "1960", IsBorrowed = false },
            new Book { Id = Guid.NewGuid(), Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Isbn = "9780743273565", Genre = "Classic", PublicationYear = "1925", IsBorrowed = false },
            new Book { Id = Guid.NewGuid(), Title = "Brave New World", Author = "Aldous Huxley", Isbn = "9780060850524", Genre = "Science Fiction", PublicationYear = "1932", IsBorrowed = false },
            new Book { Id = Guid.NewGuid(), Title = "The Catcher in the Rye", Author = "J.D. Salinger", Isbn = "9780316769488", Genre = "Fiction", PublicationYear = "1951", IsBorrowed = false }
        };

        modelBuilder.Entity<Book>().HasData(books);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        optionsBuilder.ConfigureWarnings(warnings => 
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}