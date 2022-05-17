namespace SLibrary.Api.Domain.Models;
public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long NationalId { get; set; }
    public string MobileNumber { get; set; }

    public ICollection<Book> Books { get; set; }
}

