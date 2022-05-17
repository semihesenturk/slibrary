namespace SLibrary.Common.Models.RequestModels;
public class BookCheckoutRequestModel
{
    public Guid ReservedPersonId { get; set; }
    public string ReservedPersonPhoneNumber { get; set; }
    public long NationalId { get; set; }
    public DateTime CheckedoutDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
