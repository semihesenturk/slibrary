using SLibrary.Common.Enums;

namespace SLibrary.Common.Models.ViewModels;
public class BookViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string ISBN { get; set; }

    public string PublishedYear { get; set; }

    public decimal Price { get; set; }

    public BookStatusEnum Status { get; set; }
}

