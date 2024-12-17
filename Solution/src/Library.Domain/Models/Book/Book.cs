using Library.Domain.Interfaces;

namespace Library.Domain.Models;

public class Book : IEntity
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Isbn { get; set; }
    public required string Genre { get; set; }
    public required string PublicationYear { get; set; }
    public bool IsBorrowed { get; set; }
    public int Quantity { get; set; } = 1;
}