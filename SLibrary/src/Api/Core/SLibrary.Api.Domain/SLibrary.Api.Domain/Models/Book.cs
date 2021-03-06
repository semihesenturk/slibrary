using SLibrary.Common.Enums;

namespace SLibrary.Api.Domain.Models;
public class Book : BaseEntity
{
    public string Title { get; set; }

    public string ISBN { get; set; }

    public string PublishedYear { get; set; }

    public decimal Price { get; set; }

    public BookStatusEnum Status { get; set; }

   // public Guid? UserId { get; set; }

    public User? User { get; set; }
}

