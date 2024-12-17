using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected AppDbContext()
    {
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Loan> Loans { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
}