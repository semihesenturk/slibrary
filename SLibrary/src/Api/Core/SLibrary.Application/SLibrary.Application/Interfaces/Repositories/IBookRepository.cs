using SLibrary.Api.Domain.Models;
using SLibrary.Common.Models.RequestModels;

namespace SLibrary.Application.Interfaces.Repositories;
public interface IBookRepository : IGenericRepository<Book>
{
    Task<bool> CheckInBook(BookCheckinRequestModel bookCheckinRequestModel);
    Task<bool> CheckoutBook(BookCheckoutRequestModel bookCheckoutRequestModel);

}

