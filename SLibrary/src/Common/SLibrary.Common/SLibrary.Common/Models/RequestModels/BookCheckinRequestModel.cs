namespace SLibrary.Common.Models.RequestModels;
public class BookCheckinRequestModel
{
    public Guid ReservedPersonId { get; set; }
    public string ReservedPersonPhoneNumber { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime PromisedReturnDate { get; set; }
}
