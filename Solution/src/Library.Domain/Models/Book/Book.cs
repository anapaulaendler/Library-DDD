using Library.Domain.Interfaces;

namespace Library.Domain.Models;

public class Book : IEntity
{
    public Guid Id { get; set; }
}